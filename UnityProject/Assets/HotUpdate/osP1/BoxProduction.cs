using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cfg;
using HotUpdate.osP1.Enum;
using HotUpdate.osP1.ValueObject;
using osP1.Helper;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HotUpdate.osP1
{
    public partial class BoxProduction
    {
        class Box4Container
        {
            public int SlotNum;
            public List<(BattleContainer, int)> Bullets;
        }

        //state
        public bool IsDebug { get; set; } = true;
        public int ComboNum { get; set; }
        public int TotalBoxApproximate { get; private set; }

        private int _usedBullet;

        private int _productionTime;

        public static List<(string, bool)> DebugItem { get; private set; } =
            new List<(string, bool)>()
            {
                (ItemRandomBullet, false),
                (ItemRandomBox, false),
                (ItemRandomConnection, false),
                (ItemRandomPlaceholder, false),
                (ItemAssignContainer2Slot, false),
                (ItemAssignNumber2Slot, false),
                (ItemAssignSlot2Box, false),
                (ItemBoxVo, false)
            };

        private const string ItemRandomBullet = "随机子弹";
        private const string ItemRandomBox = "随机箱子";
        private const string ItemRandomConnection = "随机连接";
        private const string ItemRandomPlaceholder = "随机占位";
        private const string ItemAssignContainer2Slot = "分配 容器 -> 槽";
        private const string ItemAssignNumber2Slot = "分配 数量 -> 槽";
        private const string ItemAssignSlot2Box = "分配 槽 -> 箱子";
        private const string ItemBoxVo = "最终产物";

        //read meta LevelConfig
        private int _bulletSegmentLength;
        private int _boxSegmentLength;
        private Dictionary<BattleContainer, BattleColor> _containerColorRelation;
        private Dictionary<BattleContainer, int> _containerUnlock = new Dictionary<BattleContainer, int>();
        private Dictionary<BattleContainer, int> _containerRemain = new Dictionary<BattleContainer, int>();


        private Dictionary<int, float> _boxWeight = new Dictionary<int, float>();
        private float _maxP;
        private float _boxInitPSame;
        private float _boxDeltaPSame;
        private float _brickPSame;
        private int _brickAmount;

        private int _brickStartIndex;
        private int _brickEndIndex;
        private int _windowSize;


        //read meta KeyValue
        private int _a;
        private int _b;

        private float K => 1f / (1f + Mathf.Pow(_a, (-_b + ComboNum) / (float)_b));
        private float P => _boxInitPSame + _boxDeltaPSame * 2f * (K - 0.5f);

        //sliding window 4 remain container
        private Dictionary<int, Level> _levelMeta;
        private Dictionary<BattleContainer, int> _containerRemainSlidingWindow = new Dictionary<BattleContainer, int>();
        private int _currentBrickIndex;
        private int _leftHp = 0;

        //reload
        private bool _isEnableReload;
        private List<BrickVo> _remainBricks;
        private Dictionary<BattleColor, BattleContainer> _colorContainerRelation;
        private int _originWindowSize;
        private int _originBulletSegmentLength;
        private int _originBoxSegmentLength;
        private bool _isGuarantee;


        public BoxProduction(LevelConfig config, Dictionary<BattleContainer, BattleColor> containerColorRelation,
            int aValue, int bValue)
        {
            //read level config
            _bulletSegmentLength = config.BulletSegmentLength;
            _boxSegmentLength = config.BoxSegmentLength;

            _originBulletSegmentLength = _bulletSegmentLength;
            _originBoxSegmentLength = _boxSegmentLength;


            var containerUnlockAndAmount = config.ContainerUnlockAndAmount.Split("|");
            foreach (var str in containerUnlockAndAmount)
            {
                var temp = str.Split("_");
                var container = System.Enum.Parse<BattleContainer>(temp[0]);
                var unlock = int.Parse(temp[1]);
                var amount = int.Parse(temp[2]);

                _containerUnlock[container] = unlock;
                _containerRemain[container] = amount;
            }

            var boxWeight = config.BoxWeight.Split("|").Select(str => str.Split("_")).ToArray();
            foreach (var str in boxWeight)
            {
                var slotNum = int.Parse(str[0]);
                var weight = int.Parse(str[1]);
                _boxWeight[slotNum] = weight;
            }

            _maxP = config.BoxMaxPDiff;
            _boxInitPSame = config.BoxInitPSame;
            _boxDeltaPSame = config.BoxDeltaPSame;

            _containerColorRelation = containerColorRelation;

            _brickPSame = config.BrickPSame;
            _brickAmount = config.BrickAmount;


            //read kv
            _a = aValue;
            _b = bValue;


            _brickStartIndex = config.StartIndex;
            _brickEndIndex = config.EndIndex;
            _windowSize = config.WindowSize;
            _originWindowSize = config.WindowSize;


            _levelMeta = MetaManager.instance.Meta.TbLevel.DataMap;
            _currentBrickIndex = _brickStartIndex;

            var segmentCount = (float)_containerRemain.Values.Sum() / _bulletSegmentLength;
            TotalBoxApproximate = (int)segmentCount * _boxSegmentLength;
        }

        public void ReloadBox(List<BrickVo> bricks, Action callback)
        {
            //guide 因为第一关是直接生成好的，如果触发了fever的重排，则需要提供_usedBullet数，取一个稍大值
            if (GamePlay.instance.LevelId == 1)
                _usedBullet = 10000;

            _isEnableReload = true;
            _remainBricks = new List<BrickVo>();
            var colorRemain = new Dictionary<BattleColor, int>();
            foreach (var vo in bricks)
            {
                if (vo.State == BrickState.Dead && vo.GenerateGroup == 0)
                    continue;

                _remainBricks.Add(vo);
            }
            
            //start logic 保底
            var guaranteeLife = Mathf.RoundToInt(
                float.Parse(MetaManager.instance.Meta.TbKV.DataMap["item_shuffle_Kr2"].Value) *
                _windowSize);
            
            var guaranteeList = new List<(BattleColor, int)>();
            var index = 0;
            for (int life = 0; life < guaranteeLife;)
            {
                if(index > _remainBricks.Count - 1)
                    break;
                
                var remainLife = guaranteeLife - life;
                var brickLife = _remainBricks[index].Life;

                var useLife = brickLife <= remainLife ? brickLife : remainLife;

                if(useLife != 0)
                    guaranteeList.Add((_remainBricks[index].Color, useLife));

                //modify life
                life += useLife;

                //modify remainBrick
                _remainBricks[index].Life -= useLife;
                if (_remainBricks[index].Life == 0)
                {
                    index++;
                }

            }
            if(index != 0)
                _remainBricks.RemoveRange(0, index);
            
            GamePlay.instance.LevelData.ClearFillQueue();
            foreach (var (color,num) in guaranteeList)
            {
                var boxVo = new BoxVo(BoxState.InMatrix);
                boxVo.Bullets = new List<StackableBulletVo>();
                var stackableBullet = new StackableBulletVo(StackableBulletState.InPanel);
                stackableBullet.Color = color;
                stackableBullet.Number = num;
                boxVo.Bullets.Add(stackableBullet);
                GamePlay.instance.LevelData.AddBoxVo2FillQueue(boxVo);
            }
            
            //end logic 保底

            foreach (var vo in _remainBricks)
            {
                if (!colorRemain.ContainsKey(vo.Color))
                    colorRemain.Add(vo.Color, vo.Life);
                else
                    colorRemain[vo.Color] += vo.Life;
            }

            var colorContainerRelation = new Dictionary<BattleColor, BattleContainer>();
            foreach (var (container, color) in GamePlay.instance.LevelData.ContainerColorRelation)
            {
                colorContainerRelation[color] = container;
            }

            _colorContainerRelation = colorContainerRelation;

            var containerRemain = new Dictionary<BattleContainer, int>();
            foreach (var (color, num) in colorRemain)
            {
                containerRemain.Add(colorContainerRelation[color], num);
            }

            _containerRemain = containerRemain;

            _containerRemainSlidingWindow.Clear();
            _currentBrickIndex = 0;
            _brickEndIndex = _remainBricks.Count - 1;
            _leftHp = 0;

            

            _isGuarantee = true;

            //临时更改，在一次生成后修改回来
            _windowSize = Mathf.RoundToInt(
                float.Parse(MetaManager.instance.Meta.TbKV.DataMap["item_shuffle_Kr2"].Value) *
                                           _windowSize);
            _windowSize = _windowSize == 0 ? 1 : _windowSize;
            
            //临时更改 需要保证至少6个子弹，至少6个盒
            _bulletSegmentLength = Mathf.RoundToInt(
                float.Parse(MetaManager.instance.Meta.TbKV.DataMap["item_shuffle_Kr1"].Value) *
                _bulletSegmentLength);
            _bulletSegmentLength = _bulletSegmentLength < 6 ? 6 : _bulletSegmentLength;
            
            _boxSegmentLength = Mathf.RoundToInt(
                float.Parse(MetaManager.instance.Meta.TbKV.DataMap["item_shuffle_Kr1"].Value) *
                _boxSegmentLength);
            _boxSegmentLength = _boxSegmentLength < 6 ? 6 : _boxSegmentLength;


            

            var gameData = GamePlay.instance.GamePlayData;
            foreach (var row in gameData.BoxView)
            {
                foreach (var cir in row)
                {
                    cir.Dispose();
                }
            }

            var levelData = GamePlay.instance.LevelData;

            var count = 0;
            var total = gameData.BoxDisplayRow * gameData.BoxDisplayCol;
            for (int i = 0; i < gameData.BoxDisplayRow; i++)
            {
                for (int j = 0; j < gameData.BoxDisplayCol; j++)
                {
                    BoxVo vo;
                    if (i == 0)
                    {
                        vo = levelData.GetOneBox();
                    }
                    else
                    {
                        vo = levelData.UpgradeSpecialBox(levelData.GetOneBox(), j);
                    }


                    gameData.BoxVo[i][j] = vo;
                    vo.Row = i;
                    vo.Col = j;
                    var view = new CommonItemRenderer(GamePlay.instance.UI.boxLayout);
                    gameData.BoxView[i][j] = view;
                    view.initCallBack += () =>
                    {
                        view.gameObject.transform.position = gameData.BoxPos[vo.Row][vo.Col];

                        count++;
                        if (count == total)
                        {
                            callback?.Invoke();
                        }
                    };
                    view.data = vo;
                }
            }


            //stamp
            for (int i = 0; i < gameData.BoxVisibleRow; i++)
            {
                for (int j = 0; j < gameData.BoxDisplayCol; j++)
                {
                    if (gameData.BoxVo[i][j].State == BoxState.PlaceHolder)
                    {
                        gameData.IsStampCover[i][j] = true;
                        var goldBox = new CommonItemRenderer(GamePlay.instance.UI.boxLayout);
                        var goldBoxVo = new GoldBoxVo(BoxState.PlaceHolder);
                        goldBox.data = goldBoxVo;
                        var iLambda = i;
                        var jLambda = j;
                        goldBox.initCallBack += () =>
                        {
                            goldBox.gameObject.transform.position = gameData.BoxPos[iLambda][jLambda];
                        };
                        gameData.StampCover.Add(goldBox);
                    }
                }
            }
        }

        public List<BoxVo> ProductBox()
        {
            if (_currentBrickIndex > _brickEndIndex && _containerRemainSlidingWindow.Sum(pair => pair.Value) == 0)
                return new List<BoxVo>();

            if (IsDebug)
            {
                _productionTime++;
                if (_productionTime == 1)
                {
                    Debug.Log("----------------------------------------------------------------------".ToGreen()
                        .ToBold());
                    Debug.Log($"子弹数量: {_containerRemain.ToData()}");
                    Debug.Log($"子弹总数: {_containerRemain.Sum(pair => pair.Value)}");
                    Debug.Log("----------------------------------------------------------------------".ToGreen()
                        .ToBold());
                }

                Debug.Log($"第 {_productionTime} 轮".ToGreen().ToBold());
            }

            if (!_isEnableReload)
            {
                if (_containerRemainSlidingWindow.Sum(pair => pair.Value) <= 0) //用完了，移动窗口
                {
                    _containerRemainSlidingWindow.Clear();
                    for (var currentHp = 0; currentHp < _windowSize;)
                    {
                        if (_currentBrickIndex > _brickEndIndex)
                            break;

                        var brick = _levelMeta[_currentBrickIndex];
                        var container = System.Enum.Parse<BattleContainer>(brick.BrickContainer);
                        if (!_containerRemainSlidingWindow.ContainsKey(container))
                            _containerRemainSlidingWindow[container] = 0;
                        if (currentHp + brick.BrickHp <= _windowSize && _leftHp == 0)
                        {
                            currentHp += brick.BrickHp;
                            _containerRemainSlidingWindow[container] += brick.BrickHp;
                            _currentBrickIndex++;
                        }
                        else if (currentHp + _leftHp <= _windowSize && _leftHp > 0)
                        {
                            currentHp += _leftHp;
                            _containerRemainSlidingWindow[container] += _leftHp;

                            _leftHp = 0;
                            _currentBrickIndex++;
                        }
                        else if (_leftHp == 0)
                        {
                            var usedHp = _windowSize - currentHp;
                            currentHp += usedHp;
                            _containerRemainSlidingWindow[container] += usedHp;
                            _leftHp = brick.BrickHp - usedHp;
                        }
                        else if (_leftHp > 0)
                        {
                            var usedHp = _windowSize - currentHp;
                            currentHp += usedHp;
                            _containerRemainSlidingWindow[container] += usedHp;
                            _leftHp -= usedHp;
                        }
                    }
                }
            }
            else //enable reload
            {
                if (_containerRemainSlidingWindow.Sum(pair => pair.Value) <= 0)
                {
                    //用完了，移动窗口
                    _containerRemainSlidingWindow.Clear();
                    for (var currentHp = 0; currentHp < _windowSize;)
                    {
                        if (_currentBrickIndex > _brickEndIndex)
                            break;

                        var brick = _remainBricks[_currentBrickIndex];
                        var container = _colorContainerRelation[brick.Color];
                        if (!_containerRemainSlidingWindow.ContainsKey(container))
                            _containerRemainSlidingWindow[container] = 0;
                        if (currentHp + brick.Life <= _windowSize && _leftHp == 0)
                        {
                            currentHp += brick.Life;
                            _containerRemainSlidingWindow[container] += brick.Life;
                            _currentBrickIndex++;
                        }
                        else if (currentHp + _leftHp <= _windowSize && _leftHp > 0)
                        {
                            currentHp += _leftHp;
                            _containerRemainSlidingWindow[container] += _leftHp;

                            _leftHp = 0;
                            _currentBrickIndex++;
                        }
                        else if (_leftHp == 0)
                        {
                            var usedHp = _windowSize - currentHp;
                            currentHp += usedHp;
                            _containerRemainSlidingWindow[container] += usedHp;
                            _leftHp = brick.Life - usedHp;
                        }
                        else if (_leftHp > 0)
                        {
                            var usedHp = _windowSize - currentHp;
                            currentHp += usedHp;
                            _containerRemainSlidingWindow[container] += usedHp;
                            _leftHp -= usedHp;
                        }
                    }
                }
            }


            _usedBullet += _bulletSegmentLength;

            //step 计算开启颜色数
            var unlockContainerList = GetUnlockContainer(_usedBullet);
            var unlockContainerNum = unlockContainerList.Count;

            //step 计算权重
            var weightUltimate = CalWeightUltimate(unlockContainerList);

            //step 计算容器数量
            var containerNum = CalContainerNum(weightUltimate);

            //step 根据容器数量，减少剩余
            foreach (var container in containerNum.Keys)
            {
                _containerRemain[container] -= containerNum[container];
                _containerRemainSlidingWindow[container] -= containerNum[container];
            }

            if (IsDebug && DebugItem[0].Item2)
            {
                Debug.Log($"本轮消耗：{containerNum.ToData()}");
                Debug.Log($"消耗后剩余：{_containerRemain.ToData()}");
            }

            //step 生成箱子 type 指每个箱子槽的数量不同
            var boxType = RandomBoxType(_boxWeight, _boxSegmentLength);
            var slotSum = boxType.Sum(pair => pair.Value * pair.Key);
            var box4ContainerList = ArrangeBox(boxType);

            if (IsDebug && DebugItem[1].Item2)
            {
                Debug.Log($"箱子种类: {boxType.ToData()}，槽数总和: {slotSum}");

                var sb = new StringBuilder();
                int boxIndex = 0;
                foreach (var tempBox in box4ContainerList)
                {
                    sb.Append($"Box{boxIndex++}: {tempBox.SlotNum}个槽");
                    sb.Append(",  ");
                }

                if (boxIndex != 0)
                    sb.Remove(sb.Length - 3, 3);
                Debug.Log(sb.ToString());
            }

            //step 生成连接
            var sameConnection = RandomSameConnectionNum(slotSum, unlockContainerNum);
            //step 计算 连接分配 权重
            var weightAssignSameConnection = CalWeightAssignSameConnection(containerNum);
            //step 分配链接
            var containerSameConnection =
                AssignSameConnection(weightAssignSameConnection, sameConnection, containerNum);

            if (IsDebug && DebugItem[2].Item2)
            {
                Debug.Log($"相同连接数量: {sameConnection}");
                //Debug.Log($"相同连接权重: {weightAssignSameConnection.ToData()}");
                Debug.Log($"连接分配: {containerSameConnection.ToData()}");
            }

            //step 随机占位，0个、1个连接占位数量是固定的，2个以上连接才会随机，范围为 [sameConnection + 1, sameConnection * 2]
            var placeholder = RandomPlaceholder(slotSum, containerSameConnection, containerNum);
            var placeholderGroup = RandomPlaceholderGroup(containerSameConnection, placeholder);

            if (IsDebug && DebugItem[3].Item2)
            {
                Debug.Log($"占位分配: {placeholder.ToData()}");
                Debug.Log($"占位分组: {placeholderGroup.ToData()}");
            }

            //step 分配容器给槽
            var slot = AssignContainer2Slot(slotSum, placeholderGroup, containerNum);

            if (IsDebug && DebugItem[4].Item2)
            {
                Debug.Log(slot.ToData());
            }

            //step 分配数量给槽
            var slotWithNum = AssignNumber2Slot(containerNum, slot);

            if (IsDebug && DebugItem[5].Item2)
            {
                Debug.Log(slotWithNum.ToData());
            }

            //step 分配槽给箱子
            box4ContainerList = AssignSlot2Box(slotWithNum, box4ContainerList);

            if (IsDebug && DebugItem[6].Item2)
            {
                var sb = new StringBuilder();
                int boxIndex = 0;
                sb.Append("[ ");
                foreach (var box4Container in box4ContainerList)
                {
                    sb.Append($"Box{boxIndex++}".ToBold());
                    sb.Append(":");
                    sb.Append($"{box4Container.Bullets.ToData()}");
                    sb.Append(", ");
                }

                sb.Remove(sb.Length - 2, 2);
                sb.Append(" ]");
                Debug.Log(sb.ToString());
            }

            var boxVoList = box4ContainerList.Select(box4Container =>
            {
                var ret = new BoxVo(BoxState.InMatrix);
                foreach (var (container, num) in box4Container.Bullets)
                {
                    ret.Bullets.Add(new StackableBulletVo(StackableBulletState.InPanel)
                    {
                        Color = _containerColorRelation[container],
                        Number = num
                    });
                }

                return ret;
            }).ToList();

            if (IsDebug && DebugItem[7].Item2)
            {
                var sb = new StringBuilder();
                var boxIndex = 0;
                sb.Append("[ ");
                foreach (var boxVo in boxVoList)
                {
                    sb.Append($"Box{boxIndex++}".ToBold());
                    sb.Append(":[ ");
                    foreach (var stackableBullet in boxVo.Bullets)
                    {
                        sb.Append($"({stackableBullet.Color}, {stackableBullet.Number})");
                        sb.Append(", ");
                    }

                    sb.Remove(sb.Length - 2, 2);
                    sb.Append(" ], ");
                }

                sb.Remove(sb.Length - 2, 2);
                sb.Append(" ]");
                Debug.Log(sb.ToString());
            }

             //保底
             if (_isGuarantee)
             {
                 _isGuarantee = false;
                 _windowSize = _originWindowSize;
                 _bulletSegmentLength = _originBulletSegmentLength;
                 _boxSegmentLength = _originBoxSegmentLength;
             }

            return boxVoList;
        }


        public string BrickArrangement()
        {
            var brickAvgHp = Mathf.RoundToInt(_containerRemain.Sum(pair => pair.Value) / (float)_brickAmount);
            var brickSegmentLength = 6; //开启颜色数最多为6，所以一段至少6个
            _bulletSegmentLength = brickSegmentLength * brickAvgHp;

            var containerRemainBackups = _containerRemain.ToDictionary(pair => pair.Key, pair => pair.Value);

            var brickArrangement = new List<(BattleContainer, int)>();
            var realBrickAmount = brickSegmentLength;
            for (int i = brickSegmentLength;
                 i < _brickAmount;
                 i += brickSegmentLength, realBrickAmount += brickSegmentLength) //注意索引
            {
                _usedBullet += _bulletSegmentLength;

                //step 计算开启颜色数
                var unlockContainerList = GetUnlockContainer(_usedBullet);
                var unlockContainerNum = unlockContainerList.Count;

                //step 计算权重
                var weightUltimate = CalWeightUltimate(unlockContainerList);

                //step 计算容器数量
                var containerNum = CalContainerNum(weightUltimate);

                //step 根据容器数量，减少剩余
                foreach (var container in containerNum.Keys)
                {
                    _containerRemain[container] -= containerNum[container];
                }

                if (IsDebug && DebugItem[0].Item2)
                {
                    Debug.Log($"本轮消耗：{containerNum.ToData()}");
                    Debug.Log($"消耗后剩余：{_containerRemain.ToData()}");
                }


                //step 几个砖块就只有几个槽位
                var slotSum = brickSegmentLength;

                if (IsDebug && DebugItem[1].Item2)
                {
                    Debug.Log($"槽数总和: {slotSum}");
                }

                //step 生成连接
                var sameConnection = RandomSameConnectionNum(slotSum, unlockContainerNum, true);

                //step 计算 连接分配 权重
                var weightAssignSameConnection = CalWeightAssignSameConnection(containerNum);

                //step 分配链接
                var containerSameConnection =
                    AssignSameConnection(weightAssignSameConnection, sameConnection, containerNum);

                if (IsDebug && DebugItem[2].Item2)
                {
                    Debug.Log($"相同连接数量: {sameConnection}");
                    //Debug.Log($"相同连接权重: {weightAssignSameConnection.ToData()}");
                    Debug.Log($"连接分配: {containerSameConnection.ToData()}");
                }

                //step 随机占位，0个、1个连接占位数量是固定的，2个以上连接才会随机，范围为 [sameConnection + 1, sameConnection * 2]
                var placeholder = RandomPlaceholder(slotSum, containerSameConnection, containerNum);

                var placeholderGroup = RandomPlaceholderGroup(containerSameConnection, placeholder);

                if (IsDebug && DebugItem[3].Item2)
                {
                    Debug.Log($"占位分配: {placeholder.ToData()}");
                    Debug.Log($"占位分组: {placeholderGroup.ToData()}");
                }

                //step 分配 container
                var slot = AssignContainer2Slot(slotSum, placeholderGroup, containerNum);

                if (IsDebug && DebugItem[4].Item2)
                {
                    Debug.Log(slot.ToData());
                }

                var slotWithNum = AssignNumber2Slot(containerNum, slot);

                if (IsDebug && DebugItem[5].Item2)
                {
                    Debug.Log(slotWithNum.ToData());
                }

                brickArrangement = brickArrangement.Concat(slotWithNum).ToList();
            }

            realBrickAmount -= brickSegmentLength;


            var sb = new StringBuilder();
            sb.AppendLine($"砖块排列: {brickArrangement.ToData()}，共计: {brickArrangement.Sum(tuple => tuple.Item2)}");

            var resume = new Dictionary<BattleContainer, int>();
            foreach (var (container, num) in brickArrangement)
            {
                if (resume.ContainsKey(container))
                    resume[container] += num;
                else
                    resume[container] = num;
            }

            var remain = new Dictionary<BattleContainer, int>();
            foreach (var container in containerRemainBackups.Keys)
            {
                if (resume.ContainsKey(container))
                    remain[container] = containerRemainBackups[container] - resume[container];
                else
                    remain[container] = containerRemainBackups[container];
            }

            sb.AppendLine($"砖块剩余: {remain.ToData()}，共计: {remain.Sum(pair => pair.Value)}");

            sb.AppendLine($"砖块配置总数: {_brickAmount}，实际砖块总数: {realBrickAmount}");

            return sb.ToString();
        }
    }
}