using System;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
    [Title("On Local List Variable Change")]
    [Category("Variables/On Local List Variable Change")]
    [Description("Executed when the Local List Variable is modified")]

    [Image(typeof(IconListVariable), ColorTheme.Type.Teal)]

    [Serializable]
    public class EventOnVariableLocalListChange : Event
    {
        [SerializeField]
        private DetectorLocalListVariable m_Variable = new DetectorLocalListVariable();
        
        // INITIALIZERS: --------------------------------------------------------------------------
        
        protected internal override void OnEnable(Trigger trigger)
        {
            base.OnEnable(trigger);
            this.m_Variable.StartListening(this.OnChange);
        }

        protected internal override void OnDisable(Trigger trigger)
        {
            base.OnDisable(trigger);
            this.m_Variable.StopListening(this.OnChange);
        }
        
        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void OnChange()
        {
            _ = this.m_Trigger.Execute(this.Self);
        }
    }
}