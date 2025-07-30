using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HotUpdate.osP1.EntitySystem;
using HotUpdate.osP1.Enum;
using HotUpdate.osP1.ValueObject;
using UnityEngine;
using UnityEngine.UI;

namespace HotUpdate.osP1
{
    public class GamePlayData
    {
        public bool DebugMode { get; private set; } = bool.Parse(MetaManager.instance.Meta.TbKV["debug_mode"].Value);

        //brick
        public List<List<BrickVo>> BrickVo { get; private set; }
        public List<List<CommonItemRenderer>> BrickView { get; private set; }
        public List<List<Vector2>> BrickPos { get; private set; }

        public List<List<BrickVo>> Data4BrickVo { get; private set; }

        public int BrickDisplayRow => DebugMode ? (BrickVoExtraRowIndex + 1) : 7 + 1;
        public int BrickDisplayCol => 7;


        public int BrickVoFirstRowIndex => 0;
        public int BrickVoLastRowIndex => BrickVo.Count - 2;
        public int BrickVoExtraRowIndex => BrickVo.Count - 1;

        //BrickVo 和 BrickView 的索引不是重叠的，而是有个bias。如果 BrickView 的索引 0，对应 BrickVo 的 0 + bias
        public int IndexBias => (BrickVoExtraRowIndex + 1) - BrickDisplayRow;

        public int BrickViewFirstRowIndex => 0;
        public int BrickViewLastRowIndex => BrickView.Count - 2;
        public int BrickViewExtraRowIndex => BrickView.Count - 1;


        //slot
        public List<BoxVo> SlotVo { get; private set; }
        public List<CommonItemRenderer> SlotView { get; private set; }
        public List<Vector3> SlotPos { get; private set; }

        public int SlotMaxNum => 7;

        public int CurrentUnlockedSlotNum { get; set; } =
            int.Parse(MetaManager.instance.Meta.TbKV.DataMap["unlock_slot_number"].Value);

        public List<bool> IsSlotEmpty { get; private set; }

        public HashSet<BoxVo> SlotSet { get; private set; }


        //box
        public List<List<BoxVo>> BoxVo { get; private set; }
        public List<List<CommonItemRenderer>> BoxView { get; private set; }
        public List<List<Vector2>> BoxPos { get; private set; }

        public List<List<BoxVo>> Data4BoxVo { get; private set; }
        
        public List<List<bool>> IsStampCover { get; private set; }
        
        public List<CommonItemRenderer> StampCover { get; private set; }

        public int BoxVisibleRow => 3;
        public int BoxDisplayRow => BoxVisibleRow + 1;// 不可见的 1行 用于播放 Box 上移动画
        public int BoxDisplayCol => _levelData.BoxCol;


        //target
        public int AttackIndex { get; private set; }

        public int ExtraAttackIndex { get; private set; }


        //private
        private readonly GamePlaySkin _ui;
        private readonly LevelData _levelData;
        private int _levelId;

        public GamePlayData(GamePlaySkin gamePlaySkin, LevelData levelData,int levelId)
        {
            _ui = gamePlaySkin;
            _levelData = levelData;
            _levelId = levelId;

            _ui.boxLayout.GetComponent<GridLayoutGroup>().constraintCount = BoxDisplayCol;
        }

        public void Init(Action callback)
        {
            var count = 0;
            var total = 3;
            Action lambda = () =>
            {
                count++;
                if (count == total)
                {
                    callback?.Invoke();
                }
            };

            InitBrick(lambda);
            InitSlot(lambda);
            InitBox(lambda);

            InitAttackIndex();
        }

        public void Dispose()
        {
            DisposeBrick();
            DisposeSlot();
            DisposeBox();
        }

        #region Init

        private void InitBrick(Action callback)
        {
            //init vo
            var brickVo = _levelData.BrickMatrix;
            brickVo.Add(new List<BrickVo>()); //extra row
            for (int i = 0; i < brickVo[0].Count; i++)
            {
                brickVo[^1].Add(new BrickVo(BrickState.Dead));
            }

            BrickVo = brickVo;
            AssignBrickRowCol();

            //init view
            var brickView = new List<List<CommonItemRenderer>>();
            for (int i = 0; i < BrickDisplayRow; i++)
            for (int j = 0; j < BrickDisplayCol; j++)
            {
                if (j == 0)
                {
                    brickView.Add(new List<CommonItemRenderer>());
                }

                brickView[i].Add(new CommonItemRenderer(GamePlay.instance.UI.brickLayout));
            }

            var name = 0;
            var count = 0;
            var total = BrickDisplayRow * BrickDisplayCol;
            for (int i = 0; i < BrickDisplayRow; i++)
            for (int j = 0; j < BrickDisplayCol; j++)
            {
                var nameLambda = name;
                var oneBrickView = brickView[i][j];
                oneBrickView.data = BrickVo[i + IndexBias][j];
                oneBrickView.initCallBack += () =>
                {
                    oneBrickView.gameObject.name = nameLambda.ToString();

                    count++;
                    if (count == total)
                        EquineScheduler.RunYieldProcedure(OnInitBrickFinished(callback));
                };
                name++;
            }

            BrickView = brickView;

            //init data
            RecordData4BrickVo();
            for(int i = 0; i <= BrickVoExtraRowIndex; i++)
            for (int j = 0; j < BrickDisplayCol; j++)
            {
                Data4BrickVo[i][j].OriginRow = i;
                Data4BrickVo[i][j].OriginCol = j;
                BrickVo[i][j].OriginRow = i;
                BrickVo[i][j].OriginCol = j;
            }
        }

        private IEnumerator OnInitBrickFinished(Action callback)
        {
            //调整子节点位置，因为赋值data时，谁先创建时不确定的
            for (int i = 0; i < BrickDisplayRow; i++)
            for (int j = 0; j < BrickDisplayCol; j++)
            {
                BrickView[i][j].gameObject.transform.SetSiblingIndex(int.Parse(BrickView[i][j].gameObject.name));
            }

            //init pos
            BrickPos = new List<List<Vector2>>();
            for (int i = 0; i < BrickDisplayRow; i++)
            for (int j = 0; j < BrickDisplayCol; j++)
            {
                if (j == 0)
                {
                    BrickPos.Add(new List<Vector2>());
                }

                BrickPos[i].Add(Vector2.zero);
            }

            //等一帧，否则位置不准确
            yield return null;

            for (int i = 0; i < BrickDisplayRow; i++)
            for (int j = 0; j < BrickDisplayCol; j++)
            {
                BrickPos[i][j] = BrickView[i][j].gameObject.transform.position;
            }

            GamePlay.instance.UI.brickLayout.GetComponent<GridLayoutGroup>().enabled = false;

            callback?.Invoke();
        }

        private void InitSlot(Action callback)
        {
            //init vo
            var slotVo = new List<BoxVo>();
            for (var i = 0; i < SlotMaxNum; i++)
            {
                var vo = new BoxVo(BoxState.PlaceHolder);
                slotVo.Add(vo);
            }

            SlotVo = slotVo;
            AssignSlotIndex();

            //init view
            var name = 0;
            var count = 0;
            var total = SlotMaxNum;
            var slotView = new List<CommonItemRenderer>();
            for (int i = 0; i < SlotMaxNum; i++)
            {
                slotView.Add(new CommonItemRenderer(GamePlay.instance.UI.slotLayout));

                var nameLambda = name;
                var oneSlotView = slotView[i];
                oneSlotView.data = SlotVo[i];
                oneSlotView.initCallBack += () =>
                {
                    oneSlotView.gameObject.name = nameLambda.ToString();

                    count++;
                    if (count == total)
                        EquineScheduler.RunYieldProcedure(OnInitSlotFinished(callback));
                };
                name++;
            }

            SlotView = slotView;


            IsSlotEmpty = new List<bool>();
            for (int i = 0; i < SlotMaxNum; i++)
            {
                IsSlotEmpty.Add(true);
            }

            SlotSet = new HashSet<BoxVo>();
        }

        private IEnumerator OnInitSlotFinished(Action callback)
        {
            //调整子节点位置，因为赋值data时，谁先创建时不确定的
            for (int i = 0; i < SlotMaxNum; i++)
            {
                SlotView[i].gameObject.transform.SetSiblingIndex(int.Parse(SlotView[i].gameObject.name));
            }

            //init pos
            SlotPos = new List<Vector3>();
            for (int i = 0; i < SlotMaxNum; i++)
            {
                SlotPos.Add(Vector3.zero);
            }

            //等一帧，否则位置不准确
            yield return null;

            for (int i = 0; i < SlotMaxNum; i++)
            {
                SlotPos[i] = SlotView[i].gameObject.transform.position;
            }

            //clear vo
            SlotVo.Clear();

            //clear view
            foreach (var cir in SlotView)
            {
                cir.Dispose();
            }

            SlotView.Clear();


            GamePlay.instance.UI.slotLayout.GetComponent<GridLayoutGroup>().enabled = false;
            callback?.Invoke();
        }

        private void InitBox(Action callback)
        {
            //init vo
            if (_levelId != 1)
            {
                var boxVo = new List<List<BoxVo>>();
                for (int i = 0; i < BoxDisplayRow; i++)
                for (int j = 0; j < BoxDisplayCol; j++)
                {
                    if (j == 0)
                        boxVo.Add(new List<BoxVo>());

                    BoxVo tempVo;
                    if (i == 0)
                    {
                        tempVo = _levelData.GetOneBox();
                    }
                    else
                    {
                        tempVo = _levelData.UpgradeSpecialBox(_levelData.GetOneBox(), j);
                    }
                    boxVo[i].Add(tempVo);
                }

                BoxVo = boxVo;
            }
            else
            {
                //创建空 boxVo 矩阵
                var tbGuideLevel = MetaManager.instance.Meta.TbGuideLevel;
                var totalRow = tbGuideLevel.DataList[^1].Row;
                var boxVo = new List<List<BoxVo>>();
                for(int i = 0;i < totalRow;i++)
                for (int j = 0; j < BoxDisplayCol; j++)
                {
                    if(j == 0)
                        boxVo.Add(new List<BoxVo>());
                    boxVo[i].Add(null);
                }
                
                //读表，为空 boxVo 矩阵赋值
                foreach (var guideLevel in tbGuideLevel.DataList)
                {
                    var tempBoxVo = new BoxVo(BoxState.InMatrix);
                    tempBoxVo.Bullets = new List<StackableBulletVo>();
                    var strBullet = guideLevel.Ball;
                    var strBulletSplit = strBullet.Split("|");
                    foreach (var innerStr in strBulletSplit)
                    {
                        var innerStrSplit = innerStr.Split("_");
                        var container = System.Enum.Parse<BattleContainer>(innerStrSplit[0]);
                        var number = int.Parse(innerStrSplit[1]);
                        var color = _levelData.ContainerColorRelation[container];
                        var stackableBulletVo = new StackableBulletVo(StackableBulletState.InPanel);
                        stackableBulletVo.Color = color;
                        stackableBulletVo.Number = number;
                        tempBoxVo.Bullets.Add(stackableBulletVo);
                    }

                    boxVo[guideLevel.Row - 1][guideLevel.Column - 1] = tempBoxVo;
                }
                
                BoxVo = boxVo;
            }
            
            
            
            AssignBoxRowCol();

            //init view
            var boxView = new List<List<CommonItemRenderer>>();
            for (int i = 0; i < BoxDisplayRow; i++)
            for (int j = 0; j < BoxDisplayCol; j++)
            {
                if (j == 0)
                    boxView.Add(new List<CommonItemRenderer>());

                boxView[i].Add(new CommonItemRenderer(GamePlay.instance.UI.boxLayout));
            }

            var name = 0;
            var count = 0;
            var total = BoxDisplayRow * BoxDisplayCol;
            for (int i = 0; i < BoxDisplayRow; i++)
            for (int j = 0; j < BoxDisplayCol; j++)
            {
                var nameLambda = name;
                var oneBoxView = boxView[i][j];
                oneBoxView.data = BoxVo[i][j];
                oneBoxView.initCallBack += () =>
                {
                    oneBoxView.gameObject.name = nameLambda.ToString();

                    count++;
                    if (count == total)
                        EquineScheduler.RunYieldProcedure(OnInitBoxFinished(callback));
                };
                name++;
            }

            BoxView = boxView;

            //init data
            RecordData4BoxVo();
            
            //use for stamp
            var isStampCover = new List<List<bool>>();
            for (int i = 0; i < BoxVisibleRow; i++)
            for (int j = 0; j < BoxDisplayCol; j++)
            {
                if(j == 0)
                    isStampCover.Add(new List<bool>());
                isStampCover[i].Add(false);
            }

            IsStampCover = isStampCover;

            StampCover = new List<CommonItemRenderer>();
        }

        private IEnumerator OnInitBoxFinished(Action callback)
        {
            //调整子节点位置，因为赋值data时，谁先创建时不确定的
            for (int i = 0; i < BoxDisplayRow; i++)
            for (int j = 0; j < BoxDisplayCol; j++)
            {
                BoxView[i][j].gameObject.transform.SetSiblingIndex(int.Parse(BoxView[i][j].gameObject.name));
            }

            //init pos
            BoxPos = new List<List<Vector2>>();
            for (int i = 0; i < BoxDisplayRow; i++)
            for (int j = 0; j < BoxDisplayCol; j++)
            {
                if (j == 0)
                {
                    BoxPos.Add(new List<Vector2>());
                }

                BoxPos[i].Add(Vector2.zero);
            }

            //等一帧，否则位置不准确
            yield return null;

            for (int i = 0; i < BoxDisplayRow; i++)
            for (int j = 0; j < BoxDisplayCol; j++)
            {
                BoxPos[i][j] = BoxView[i][j].gameObject.transform.position;
            }

            GamePlay.instance.UI.boxLayout.GetComponent<GridLayoutGroup>().enabled = false;

            callback?.Invoke();
        }

        #endregion

        #region Dispose

        private void DisposeBrick()
        {
            foreach (var list in BrickView)
            {
                foreach (var cir in list)
                {
                    cir.Dispose();
                }
            }

            BrickView.Clear();

            _ui.brickLayout.GetComponent<GridLayoutGroup>().enabled = true;
        }

        private void DisposeSlot()
        {
            foreach (var vo in SlotSet)
            {
                EntityManager.instance.RemoveEntity(vo);
               vo.Cir.Dispose();
            }

            SlotSet.Clear();

            _ui.slotLayout.GetComponent<GridLayoutGroup>().enabled = true;
        }

        private void DisposeBox()
        {
            foreach (var list in BoxView)
            {
                foreach (var cir in list)
                {
                    cir.Dispose();
                }
            }

            BoxView.Clear();

            _ui.boxLayout.GetComponent<GridLayoutGroup>().enabled = true;
        }

        #endregion

        public void InitAttackIndex()
        {
            AttackIndex = Data4BrickVo.Count - 2;
            ExtraAttackIndex = Data4BrickVo.Count - 1;
        }

        public bool IsNeedSetAttackIndex()
        {
            return Data4BrickVo[AttackIndex].All(vo => vo.State == BrickState.Dead) &&
                   Data4BrickVo[ExtraAttackIndex].All(vo => vo.State == BrickState.Dead);
        }

        public void SetAttackIndex()
        {
            //只需调整ExtraAttackIndex上面的行数即可
            for (int i = 0; i < ExtraAttackIndex; i++)
            for (int j = 0; j < BrickDisplayCol; j++)
            {
                Data4BrickVo[i][j].Row++;
            }

            if (AttackIndex == 0)
                return;

            AttackIndex--;
            ExtraAttackIndex--;
        }

        public void AssignBrickRowCol()
        {
            for (var i = 0; i <= BrickVoExtraRowIndex; i++)
            for (var j = 0; j < BrickDisplayCol; j++)
            {
                BrickVo[i][j].Row = i;
                BrickVo[i][j].Col = j;
            }
        }

        public void AssignSlotIndex()
        {
            for (int i = 0; i < SlotMaxNum; i++)
            {
                SlotVo[i].SlotIndex = i;
            }
        }

        public void AssignBoxRowCol()
        {
            for (var i = 0; i < BoxDisplayRow; i++)
            for (var j = 0; j < BoxDisplayCol; j++)
            {
                BoxVo[i][j].Row = i;
                BoxVo[i][j].Col = j;
            }
        }

        public void RecordData4BrickVo()
        {
            Data4BrickVo ??= new List<List<BrickVo>>();
            Data4BrickVo.Clear();
            for (int i = 0; i <= BrickVoExtraRowIndex; i++)
            for (int j = 0; j < BrickDisplayCol; j++)
            {
                if (j == 0)
                    Data4BrickVo.Add(new List<BrickVo>());

                Data4BrickVo[i].Add(BrickVo[i][j].Clone());
            }
        }


        public void RecordData4BoxVo()
        {
            Data4BoxVo ??= new List<List<BoxVo>>();
            Data4BoxVo.Clear();
            for (int i = 0; i < BoxDisplayRow; i++)
            for (int j = 0; j < BoxDisplayCol; j++)
            {
                if (j == 0)
                    Data4BoxVo.Add(new List<BoxVo>());

                Data4BoxVo[i].Add(BoxVo[i][j].Clone());
            }
        }

        public void SetAllSlotNotLoad()
        {
            foreach (var vo in SlotSet)
            {
                vo.IsLoadBullet = false;
            }
        }


        public void PassVo2BrickView(int row, int col)
        {
            BrickView[row - IndexBias][col].data = BrickVo[row][col];
        }


        public void PassVo2BoxView(int row, int col)
        {
            BoxView[row][col].data = BoxVo[row][col];
        }


        public bool IsExistSlotEmpty()
        {
            var ret = false;
            //不能linq
            for (var i = 0; i < CurrentUnlockedSlotNum; i++)
            {
                if (IsSlotEmpty[i])
                {
                    ret = true;
                    break;
                }
            }

            return ret;
        }


        public bool IsAllSlotEmpty()
        {
            var ret = true;
            for (var i = 0; i < CurrentUnlockedSlotNum; i++)
            {
                if (!IsSlotEmpty[i])
                {
                    ret = false;
                    break;
                }
            }

            return ret;
        }

        public bool IsBoxEmpty(BoxVo vo) => vo.Bullets.All(sbVo => sbVo.State == StackableBulletState.Empty);

        public bool IsLastRowBrickAllDead() => BrickVo[BrickVoLastRowIndex].All(vo => vo.State == BrickState.Dead);

        public bool IsExtraRowBrickAllDead() => BrickVo[BrickVoExtraRowIndex].All(vo => vo.State == BrickState.Dead);

        public bool IsBrickAllDead() => BrickVo.SelectMany(list => list).All(vo => vo.State == BrickState.Dead);


        public bool IsAllLoadBullet() => SlotSet.All(vo => vo.IsLoadBullet);

        public List<BrickVo> FetchRemainBrick()
        {
            //收集
            var ret = new List<BrickVo>();
            for (int i = ExtraAttackIndex; i >= 0; i--)
            {
                for (int j = 0; j < BrickDisplayCol; j++)
                {
                    ret.Add(Data4BrickVo[i][j].Clone()); 
                }
            }
            
            //排除slot中的
            var slotColor = new Dictionary<BattleColor, int>();
            foreach (var vo in SlotSet)
            {
                //load bullet 只消耗 Data4AI的数据
                foreach (var stackableBulletVo in vo.Data4Ai.Bullets)
                {
                    if(stackableBulletVo.State == StackableBulletState.Empty)
                        continue;
                    
                    var color = stackableBulletVo.Color;
                    var num = stackableBulletVo.Number;
                    if (!slotColor.ContainsKey(color))
                    {
                        slotColor.Add(color, num);
                    }
                    else
                    {
                        slotColor[color] += num;
                    }
                }
            }
            
            foreach (var vo in ret)
            {
                
                var color = vo.Color;
                if (slotColor.ContainsKey(color))
                {
                    var min = Mathf.Min(vo.Life, slotColor[color]);
                    slotColor[color] -= min;
                    if (slotColor[color] == 0)
                        slotColor.Remove(color);
                    
                    vo.Life -= min;
                    if(vo.Life == 0)
                        vo.State = BrickState.Dead;
                    
                }
            }

            return ret;
        }

        public bool IsBrickMatrixMoving()
        {
            for (var i = 0; i < BrickDisplayRow - 1; i++)
            for (var j = 0; j < BrickDisplayCol; j++)
            {
                var brickVo = BrickVo[i + IndexBias][j];
                if(brickVo.IsMoving)
                    return true;
                
            }
            return false;
        }

        public bool IsBrickMatrixLastRowMoving()
        {
            for (int j = 0; j < BrickDisplayCol; j++)
            {
                if(BrickVo[BrickVoLastRowIndex][j].IsMoving)
                    return true;
            }
            return false;
        }
    }
}