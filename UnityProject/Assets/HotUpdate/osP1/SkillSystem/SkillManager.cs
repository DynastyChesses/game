using System;
using System.Collections.Generic;
using UnityEngine;

namespace HotUpdate.osP1.SkillSystem
{
    public class SkillManager:Singleton<SkillManager>
    {
        private HashSet<Type> _skills;
        
        private Action<UpdateTimeInfo> _skillGlobalUpdate;

        private Dictionary<Type, Action> _skillGlobalStartDict;
        private Dictionary<Type,Action<UpdateTimeInfo>> _skillGlobalUpdateDict;
        private Dictionary<Type, Action> _skillGlobalEndDict;

        private int _updatorId = EquineScheduler.INVALID;
        
        public override void Dispose()
        {
            EquineScheduler.RemoveLimitUpdator(ref _updatorId);
        }

        public override void Init()
        {
            _skills = new HashSet<Type>();
            
            _skillGlobalStartDict = new Dictionary<Type, Action>();
            _skillGlobalUpdateDict = new Dictionary<Type, Action<UpdateTimeInfo>>();
            _skillGlobalEndDict = new Dictionary<Type, Action>();

            _updatorId = EquineScheduler.AddFrameLimitUpdator(0, OnUpdate);
        }

        private void OnUpdate(int a,object b,UpdateTimeInfo time)
        {
            _skillGlobalUpdate?.Invoke(time);
        }

        public void RegisterSkill(Type skillType)
        {
            if (_skills.Contains(skillType))
            {
                Debug.LogError("Skill Already Register!");
                return;
            }

            var globalStartMethodInfo = skillType.GetMethod("GlobalStart");
            if (globalStartMethodInfo == null)
                globalStartMethodInfo = skillType.BaseType.GetMethod("GlobalStart");
            
            var globalUpdateMethodInfo = skillType.GetMethod("GlobalUpdate");
            if(globalUpdateMethodInfo == null)
                globalUpdateMethodInfo = skillType.BaseType.GetMethod("GlobalUpdate");
            
            var globalEndMethodInfo = skillType.GetMethod("GlobalEnd");
            if(globalEndMethodInfo == null)
                globalEndMethodInfo = skillType.BaseType.GetMethod("GlobalEnd");
            
            _skillGlobalStartDict[skillType] = (Action)globalStartMethodInfo.CreateDelegate(typeof(Action));
            _skillGlobalUpdateDict[skillType] = (Action<UpdateTimeInfo>)globalUpdateMethodInfo.CreateDelegate(typeof(Action<UpdateTimeInfo>));
            _skillGlobalEndDict[skillType] = (Action)globalEndMethodInfo.CreateDelegate(typeof(Action));
            
            _skillGlobalStartDict[skillType]();
            _skillGlobalUpdate += _skillGlobalUpdateDict[skillType];
            
            _skills.Add(skillType);
        }

        

        public void RegisterSkill(List<Type> skillTypes)
        {
            foreach (var skillType in skillTypes)
            {
                RegisterSkill(skillType);
            }
        }
        
        public void UnRegisterSkill(Type skillType)
        {
            if (_skills.Contains(skillType))
            {
                _skillGlobalStartDict.Remove(skillType);
                
                _skillGlobalUpdate -= _skillGlobalUpdateDict[skillType];
                _skillGlobalUpdateDict.Remove(skillType);
                
                _skillGlobalEndDict[skillType]();
                _skillGlobalEndDict.Remove(skillType);
                
                _skills.Remove(skillType);
            }
        }

        public void UnRegisterSkill(List<Type> skillTypes)
        {
            foreach (var skillType in skillTypes)
            {
                UnRegisterSkill(skillType);
            }
        }

        public void UseSkill(BaseSkill skill)
        {
            skill.SkillStart();
        }
        
    }
}