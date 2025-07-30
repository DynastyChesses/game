using System;
using System.Collections;
using System.Linq;
using HotUpdate.osP1.Event;
using HotUpdate.osP1.SkillSystem;
using HotUpdate.osP1.SkillSystem.Skill;
using UnityEngine;

namespace HotUpdate.osP1
{
    public class Fever
    {
        public float FeverAnimDuration = 1.5f;
        public float ChangeColorInterver = 0.1f;
        public float FeverNeedEnergyP1 { get; private set; }
        public float FeverNeedEnergyP2 { get; private set; }
        public float FeverNeedEnergyP3 { get; private set; }
        public float ComboNeedNumP1;
        public float ComboNeedNumP2;
        public float ComboNeedNumP3;
        public float ComboNeedNumP4;
        public float ComboNeedNumP5;
        

        
        public int ComboNum;
        public bool IsFever { get; private set; }

        private float _currentFeverTime;
        private float _endFeverTime;

        private float _currentClearTime;
        private float _endClearTime;

        private float _feverDelta;
        private float _feverEnergy;
        private float _feverDurationP1;
        private float _feverDurationP2;
        private float _feverDurationP3;

        private Vector3 _maskLeftStartPos;
        private Vector3 _maskRightStartPos;
        
        private UseRefresh _skill;
        private bool _isMaskClose;
        private bool _isMaskCloseFinish;
        private bool _isEnding;
        private int _updatorId;



        public Fever()
        {
            _currentClearTime = 0f;
            _endClearTime = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["combo_duration"].Value) / 1000f;

            _feverDelta = float.Parse(MetaManager.instance.Meta.TbKV.DataMap["fever_progress_delta"].Value);
            _feverEnergy = float.Parse(MetaManager.instance.Meta.TbKV.DataMap["fever_progress_initial"].Value);

            FeverNeedEnergyP1 = float.Parse(MetaManager.instance.Meta.TbKV.DataMap["fever_progress_1"].Value);
            FeverNeedEnergyP2 = float.Parse(MetaManager.instance.Meta.TbKV.DataMap["fever_progress_2"].Value);
            FeverNeedEnergyP3 = float.Parse(MetaManager.instance.Meta.TbKV.DataMap["fever_progress_3"].Value);

            var scale = float.Parse(MetaManager.instance.Meta.TbKV.DataMap["fever_extratime_rate"].Value);
            _feverDurationP1 = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["fever_time_1"].Value) / 1000f +
                               UseRefresh.MaskMoveDuration * scale;
            _feverDurationP2 = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["fever_time_2"].Value) / 1000f +
                               UseRefresh.MaskMoveDuration * scale;
            _feverDurationP3 = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["fever_time_3"].Value) / 1000f +
                               UseRefresh.MaskMoveDuration * scale;

            ComboNeedNumP1 = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["combo_1"].Value);
            ComboNeedNumP2 = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["combo_2"].Value);
            ComboNeedNumP3 = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["combo_3"].Value);
            ComboNeedNumP4 = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["combo_4"].Value);
            ComboNeedNumP5 = int.Parse(MetaManager.instance.Meta.TbKV.DataMap["combo_5"].Value);

            _updatorId = EquineScheduler.AddFrameLimitUpdator(0,OnUpdate);
            
            ApplicationFacade.instance.SendNotification(GamePlayUIEvent.FeverEnergyInc,GetFillAmountByEnergy(_feverEnergy));
        }
        
        public void Dispose()
        {
            EquineScheduler.RemoveLimitUpdator(ref _updatorId);
        }

        private void OnUpdate(int a,object b,UpdateTimeInfo time)
        {
            _currentClearTime += time.deltaTime;
            if (_currentClearTime >= _endClearTime)
            {
                ComboNum = 0;
                _currentClearTime = 0f;
            }

            ApplicationFacade.instance.SendNotification(GamePlayUIEvent.RenderCombo, (ComboNum, CalculatePercentage()));

            if (IsFever)
            {
                _currentFeverTime += time.deltaTime;
                
                var energy = _feverEnergy * (_endFeverTime - _currentFeverTime) / _endFeverTime;
                energy = Mathf.Max(0f, energy);
                ApplicationFacade.instance.SendNotification(GamePlayUIEvent.FeverEnergyDec, GetFillAmountByEnergy(energy));
                
                if (_currentFeverTime + UseRefresh.MaskMoveDuration >= _endFeverTime && !_isMaskClose)
                {
                    _isMaskClose = true;
                    _skill.CloseMask(() => _isMaskCloseFinish = true);
                }
                
                if (_currentFeverTime >= _endFeverTime && _isMaskCloseFinish && !_isEnding)
                {
                    MoveBox2Slot.IsAllowClick = false;
                    EquineScheduler.RunYieldProcedure(EndFever());
                }
            }
            
        }
        
        public void AddCombo(bool isAddFeverEnergy)
        {
            ComboNum++;
            _currentClearTime = 0f;

            if (IsFever)
                return;
            if (ComboNum >= 2 && isAddFeverEnergy)
            {
                if (GamePlay.instance.IsGuideMode && GamePlay.instance.GuidePhase == 4)
                {
                    ApplicationFacade.instance.SendNotification(GamePlayUIEvent.GuideNextPhase);
                    GamePlay.instance.GuidePhase++;
                    GameLaunch.PauseGame();
                }
                
                _feverEnergy += _feverDelta;
                if (_feverEnergy >= FeverNeedEnergyP3)
                    _feverEnergy = FeverNeedEnergyP3;

                ApplicationFacade.instance.SendNotification(GamePlayUIEvent.FeverEnergyInc, GetFillAmountByEnergy(_feverEnergy));
            }
        }

        public IEnumerator StartFever()
        {
            if (IsFever)
                yield break;

            if (_feverEnergy < FeverNeedEnergyP1)
                yield break;
            
            var gameData = GamePlay.instance.GamePlayData;
            
            //统计持续时间
            var duration = 0f;
            if (_feverEnergy < FeverNeedEnergyP2)
            {
                duration = _feverDurationP1;
            }
            else if (_feverEnergy < FeverNeedEnergyP3)
            {
                duration = _feverDurationP2;
            }
            else
            {
                duration = _feverDurationP3;
            }

            if (GamePlay.instance.IsGuideMode &&
                GamePlay.instance.GuidePhase == 6)
            {
                ApplicationFacade.instance.SendNotification(GamePlayUIEvent.GuideNextPhase);
            }

            IsFever = true;
            _currentFeverTime = 0f;
            _endFeverTime = duration;
            _skill = new UseRefresh(true);
            SkillManager.instance.UseSkill(_skill);

            
            ApplicationFacade.instance.SendNotification(GamePlayUIEvent.StartFever);
            
            //球变色
            MoveBox2Slot.IsAllowClick = false;
            foreach (var vo in gameData.SlotSet)
            {
                foreach (var bulletVo in vo.Bullets)
                {
                    bulletVo.IsFeverStackableBullet = true;
                    if (bulletVo.CommonItemRenderer != null)
                        bulletVo.CommonItemRenderer.data = bulletVo;
                }
            }
            
            //slot中的球变色之后可以被发射
            LoadBullet.ForceLoadBullet();

            
            yield return new WaitForSeconds(ChangeColorInterver);

            var count = 0;
            var rowCount = gameData.BoxDisplayRow;
            foreach (var row in gameData.BoxVo)
            {
                count++;
                foreach (var boxVo in row)
                {
                    foreach (var bulletVo in boxVo.Bullets)
                    {
                        bulletVo.IsFeverStackableBullet = true;
                        gameData.PassVo2BoxView(boxVo.Row, boxVo.Col);
                    }
                }

                if (count < rowCount)
                    yield return new WaitForSeconds(ChangeColorInterver);
            }

            MoveBox2Slot.IsAllowClick = true;
        }

        private IEnumerator EndFever()
        {
            if(_isEnding)
                yield break;
            
            _isEnding = true;

            
            var countEndItem = 0;
            var totalEndItem = 1;
            Action endCallback = () =>
            {
                countEndItem++;
                if (countEndItem == totalEndItem)
                {
                    _isEnding = false;
                    _isMaskClose = false;
                    _isMaskCloseFinish = false;
                    
                    IsFever = false;
                    _feverEnergy = 0f;
                    _currentFeverTime = 0f;
                    
                    MoveBox2Slot.IsAllowClick = true;
                }
            };



            while (!MoveBox2Slot.IsAnimationFinished || !BoxMatrixMoveUp.IsAnimationFinished)
            {
                yield return null;
            }
            
            LoadBullet.ForceLoadBullet();
            _skill.Refresh(endCallback);
            
            //如果游戏胜利了则走ResetFever逻辑，而不是此处EndFever
            ApplicationFacade.instance.SendNotification(GamePlayUIEvent.EndFever);
        }

        

     
        private float CalculatePercentage() => (_endClearTime - _currentClearTime) / _endClearTime;
        
        private (float,int) GetFillAmountByEnergy(float energy)
        {
            var startNum = 0.15f;
            var endNum = 0.55f;
        
            float ret;
            int phase = 0;
            float ratio = 0f;
            if (energy <= FeverNeedEnergyP1)
            {
                ratio = energy / FeverNeedEnergyP1;
                phase = 1;
            }
            else if (energy <= FeverNeedEnergyP2)
            {
                ratio = (energy-FeverNeedEnergyP1) / (FeverNeedEnergyP2 - FeverNeedEnergyP1);
                phase = 2;
            }else if (energy <= FeverNeedEnergyP3)
            {
                ratio = (energy-FeverNeedEnergyP2) / (FeverNeedEnergyP3 - FeverNeedEnergyP2);
                phase = 3;
            }
            else
            {
                Debug.LogError("Over P3 energy");
            }
            ret = 0.15f + ratio * (endNum - startNum);
            return (ret, phase);
        }

        public void DebugFillEnergy()
        {
            if(IsFever)
                return;
            
            _feverEnergy = FeverNeedEnergyP3;
            ApplicationFacade.instance.SendNotification(GamePlayUIEvent.FeverEnergyInc, GetFillAmountByEnergy(_feverEnergy));
        }
        
        //新手引导
        public void GuideFillEnergy()
        {
            if(IsFever)
                return;
            
            _feverEnergy = FeverNeedEnergyP1;
            ApplicationFacade.instance.SendNotification(GamePlayUIEvent.FeverEnergyInc, GetFillAmountByEnergy(_feverEnergy));
        }
    }
}