using System;

namespace HotUpdate.osP1.ValueObject
{

    public enum CapybaraAction
    {
        AttackLowForm,
        AttackHighForm,
        IdleLowForm,
        IdleHighForm,
        Sleepy,
        ChangeToLowForm,
        ChangeToHighForm
    }
    
    public class CapybaraVo
    {
        public CapybaraAction CapybaraAction;
        public Action Callback;
    }
}