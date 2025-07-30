using System.Collections.Generic;
using System.Linq;
using HotUpdate.osP1.Enum;
using HotUpdate.osP1.ValueObject;
using osP1.Helper;
using UnityEngine;

namespace HotUpdate.osP1
{
    public class LevelData
    {
        public int LevelId { get; private set; }
        
        public bool IsHardMode { get; private set; }
        public bool IsLimitTimeMode { get; private set; }
        public int FallInterval { get; private set; }

        public Dictionary<BattleContainer, BattleColor> ContainerColorRelation { get; private set; } =
            new Dictionary<BattleContainer, BattleColor>();

        public int BoxRow { get; private set; } = 3;
        public int BoxCol { get; private set; }
        public WinCondition WinCondition { get; private set; }
        public int WinConditionAnyAmount { get; private set; }

        public Dictionary<BattleColor, int> WinConditionSpecificAmount { get; private set; } =
            new Dictionary<BattleColor, int>();

        public BoxProduction BoxProduction { get; private set; }

        public List<List<BrickVo>> BrickMatrix { get; private set; }

        public int BrickMatrixRow { get; private set; }
        public int BrickMatrixCol { get; private set; } = 7;
        
        public float ProgressRate { get; private set; }
        
        public float FailRate { get; private set; }


        private List<BoxGeneratorVo> _boxGeneratorList = new List<BoxGeneratorVo>();
        private int _randomBoxNumber;
        private float _randomBoxProbability;

        private int _boxNumberPerColApproximate;
        private Dictionary<int, int> _colProductNumber = new Dictionary<int, int>();

        private int _guideFeverIndex;


        public LevelData(int level, bool needLoadBrickMatrix = true)
        {
            //meta levelConfig
            var levelConfigMeta = MetaManager.instance.Meta.TbLevelConfig.DataMap[level];

            LevelId = level;
            
            if (LevelId == 1)
                _guideFeverIndex = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["guide_fevertrigger_brickid"].Value);

            IsHardMode = levelConfigMeta.HardMode == 1;

            IsLimitTimeMode = levelConfigMeta.FallInterval != 0;

            FallInterval = levelConfigMeta.FallInterval;

            BoxCol = levelConfigMeta.BoxCol;


            var containerColorRelation = levelConfigMeta.ContainerColorRelation.Split("|");
            var remainColor = System.Enum.GetValues(typeof(BattleColor)).Cast<BattleColor>().ToList().Shuffle(); //随机打乱
            var currentIndex = 0;
            foreach (var str in containerColorRelation) //先赋予x,y,z颜色
            {
                var temp = str.Split("_");
                var container = System.Enum.Parse<BattleContainer>(temp[0]);
                var color = System.Enum.Parse<BattleColor>(temp[1]);
                if (container is BattleContainer.X or BattleContainer.Y or BattleContainer.Z) //x,y,z每局使用固定颜色
                {
                    ContainerColorRelation[container] = color;
                    remainColor.Remove(color);
                }
            }

            foreach (var str in containerColorRelation) //再赋予其余颜色
            {
                var temp = str.Split("_");
                var container = System.Enum.Parse<BattleContainer>(temp[0]);
                if (container is BattleContainer.X or BattleContainer.Y or BattleContainer.Z)
                {
                    continue;
                }
                else //其余颜色每局随机
                {
                    ContainerColorRelation[container] = remainColor[currentIndex++];
                }
            }

            var conditions = levelConfigMeta.WinCondition.Split("|").Select(condition => condition.Split("_"))
                .ToArray();
            if (conditions[0][0] == WinCondition.Any.ToString())
            {
                WinCondition = WinCondition.Any;
                WinConditionAnyAmount = int.Parse(conditions[0][1]);
            }
            else
            {
                WinCondition = WinCondition.Specific;
                foreach (var condition in conditions)
                {
                    var container = System.Enum.Parse<BattleContainer>(condition[0]);
                    var amount = int.Parse(condition[1]);
                    WinConditionSpecificAmount[ContainerColorRelation[container]] = amount;
                }
            }

            if (levelConfigMeta.BoxGeneratorInfo != "")
            {
                var boxGeneratorInfoList = levelConfigMeta.BoxGeneratorInfo.Split("|");
                foreach (var rawStr in boxGeneratorInfoList)
                {
                    var str = rawStr.Split("_");
                    var vo = new BoxGeneratorVo(BoxState.InMatrix);
                    vo.Pos = float.Parse(str[0]);
                    vo.ColIndex = int.Parse(str[1]) - 1;
                    vo.Direction = System.Enum.Parse<BoxGeneratorDirection>(str[2]);
                    vo.ChildNumber = int.Parse(str[3]);

                    _boxGeneratorList.Add(vo);
                }
            }


            var kvMeta = MetaManager.instance.Meta.TbKV.DataMap;
            var a = int.Parse(kvMeta["level_kdiff_a"].Value);
            var b = int.Parse(kvMeta["level_kdiff_b"].Value);

            BoxProduction = new BoxProduction(levelConfigMeta, ContainerColorRelation, a, b);
            if (needLoadBrickMatrix)
            {
                var matrix = LoadBrickArrangement(levelConfigMeta.StartIndex, levelConfigMeta.EndIndex);
                var nestList = new List<List<BrickVo>>();
                for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == 0)
                        nestList.Add(new List<BrickVo>());
                    
                    
                    
                    nestList[i].Add(matrix[i, j]);
                }

                BrickMatrix = nestList;
            }

            _randomBoxNumber = levelConfigMeta.RandomBoxNum;
            _randomBoxProbability = (float)_randomBoxNumber / BoxProduction.TotalBoxApproximate;

            _boxNumberPerColApproximate = Mathf.RoundToInt((float)BoxProduction.TotalBoxApproximate / BoxCol);

            ProgressRate = levelConfigMeta.ProgresssRate;
            FailRate = levelConfigMeta.FailRate;

        }

        private Queue<BoxVo> _fillQueue = new Queue<BoxVo>();

        private BrickVo[,] LoadBrickArrangement(int startIndex, int endIndex)
        {
            var levelMeta = MetaManager.instance.Meta.TbLevel.DataMap;
            BrickMatrixRow = levelMeta[endIndex].Row;
            var ret = new BrickVo[BrickMatrixRow, BrickMatrixCol];

            //step read brick
            for (int i = startIndex; i <= endIndex; i++)
            {
                var brickConfig = levelMeta[i];
                var type = System.Enum.Parse<BrickType>(brickConfig.BrickType);
                BrickVo brickVo = type switch
                {
                    BrickType.Brick => new BrickVo(BrickState.Live),
                    BrickType.Boom => new BombVo(BrickState.Live),
                    BrickType.Spawn => new BrickGeneratorVo(BrickState.Live)
                };
                
                //GuideLevel
                if (LevelId == 1 && i == _guideFeverIndex)
                {
                    brickVo.IsGuideFever = true;
                }


                var container = System.Enum.Parse<BattleContainer>(brickConfig.BrickContainer);
                brickVo.Color = ContainerColorRelation[container];
                brickVo.Life = brickConfig.BrickHp;

                //for brick generator
                brickVo.GenerateGroup = brickConfig.SpawnGroup;

                //for bomb
                if (brickVo is BombVo bombVo)
                {
                    bombVo.CountDown = brickConfig.BombCountDown;
                }

                //assign ret
                ret[brickConfig.Row - 1, brickConfig.Column - 1] = brickVo;
            }

            //step 填充空余块
            for (int i = 0; i < BrickMatrixRow; i++)
            for (int j = 0; j < BrickMatrixCol; j++)
            {
                ret[i, j] ??= new BrickVo(BrickState.Dead);
            }

            //step 处理group，用于 brick generator
            for (int i = 0; i < BrickMatrixRow; i++)
            for (int j = 0; j < BrickMatrixCol; j++)
            {
                if (ret[i, j] is BrickGeneratorVo) //BrickGenerator 本身不隐藏
                    continue;
                if (ret[i, j].GenerateGroup != 0) //非0生成组 用于 BrickGenerator 死后生成
                    ret[i, j].State = BrickState.Dead;
            }

            int left = 0;
            int right = BrickMatrixRow - 1;
            while (left < right)
            {
                for (var i = 0; i < BrickMatrixCol; i++)
                {
                    (ret[left, i], ret[right, i]) = (ret[right, i], ret[left, i]);
                }

                left++;
                right--;
            }

            return ret;
        }

        public BoxVo GetOneBox()
        {
            BoxVo ret;

            if (_fillQueue.Count > 0)
            {
                ret = _fillQueue.Dequeue();
            }
            else
            {
                var list = BoxProduction.ProductBox(); //可能产生空列表
                foreach (var vo in list)
                {
                    _fillQueue.Enqueue(vo);
                }

                ret = _fillQueue.Count > 0 ? _fillQueue.Dequeue() : new BoxVo(BoxState.PlaceHolder);
            }

            return ret;
        }

        public void AddBoxVo2FillQueue(BoxVo boxVo)
        {
            _fillQueue.Enqueue(boxVo);
        }

        public void ClearFillQueue()
        {
            _fillQueue.Clear();
        }

        public BoxVo UpgradeSpecialBox(BoxVo boxVo, int col, bool skipBoxGenerator = false)
        {
            if (!_colProductNumber.ContainsKey(col))
                _colProductNumber.Add(col, 1);
            else
                _colProductNumber[col]++;

            //BoxGenerator 先生成
            //skip用于，禁止盒子生成器，再生成盒子生成器
            if (!skipBoxGenerator && _boxGeneratorList.Count(vo => vo.ColIndex == col) > 0)
            {
                var boxGeneratorVo =
                    _boxGeneratorList.Where(vo => vo.ColIndex == col).OrderBy(vo => vo.Pos).First();
                var currentPos = (float)_colProductNumber[col] / _boxNumberPerColApproximate;
                if (currentPos >= boxGeneratorVo.Pos)
                {
                    _boxGeneratorList.Remove(boxGeneratorVo);

                    //目前是先生成正常的box，再升级为random box 或者 box generator，所以此处消耗了一个正常箱子，需要加到队列里
                    boxGeneratorVo.BoxQueue.Enqueue(boxVo);

                    //添加其他的BoxVo
                    while (boxGeneratorVo.BoxQueue.Count < boxGeneratorVo.ChildNumber)
                    {
                        var vo = GetOneBox();
                        if (vo.State != BoxState.PlaceHolder)
                            boxGeneratorVo.BoxQueue.Enqueue(vo);
                        else
                            break;
                    }

                    boxGeneratorVo.ChildNumber = boxGeneratorVo.BoxQueue.Count;
                    return boxGeneratorVo;
                }
            }

            if (_randomBoxNumber > 0 && boxVo.State != BoxState.PlaceHolder &&
                RandomHelper.RandomFloat(0f, 1f) < _randomBoxProbability)
            {
                _randomBoxNumber--;
                var randomBoxVo = new RandomBoxVo(boxVo);
                return randomBoxVo;
            }

            return boxVo;
        }
    }
}