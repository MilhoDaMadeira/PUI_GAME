using System;
using UnityEngine;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.Variables
{
    [Title("Global List Variable")]
    [Category("Variables/Global List Variable")]
    
    [Description("Sets the numeric value of a Global List Variable")]
    [Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]

    [Serializable] [HideLabelsInEditor]
    public class SetNumberGlobalList : PropertyTypeSetNumber
    {
        [SerializeField]
        protected FieldSetGlobalList m_Variable = new FieldSetGlobalList(ValueNumber.TYPE_ID);

        public override void Set(double value, Args args) => this.m_Variable.Set(value);
        public override void Set(double value, GameObject gameObject) => this.m_Variable.Set(value);

        public override double Get(Args args) => (double) this.m_Variable.Get();
        public override double Get(GameObject gameObject) => (double) this.m_Variable.Get();
        
        public static PropertySetNumber Create => new PropertySetNumber(
            new SetNumberGlobalList()
        );
        
        public override string String => this.m_Variable.ToString();
    }
}