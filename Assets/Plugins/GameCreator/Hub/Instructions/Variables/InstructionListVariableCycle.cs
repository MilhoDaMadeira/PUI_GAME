using System;
using UnityEngine;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using System.Collections.Generic;

namespace GameCreator.Runtime.VisualScripting
{
    [Version(1, 0, 0)]
    [Title("Cycle List")]
    [Description("Moves first element of a list to the bottom of the list")]

    [Image(typeof(IconRepeat), ColorTheme.Type.Teal, typeof(OverlayListVariable))]

    [Category("Variables/Cycle List")]

    [Parameter("List Variable", "Local List or Global List for which elements are cycled")]

    [Keywords("Order", "Change", "Array", "List", "Variables", "Loop", "Cycle")]
    [Serializable]
    public class InstructionListVariableCycle : Instruction
    {
        public override string Title => $"Cycle elements on {this.m_ListVariable}";

        [SerializeField]
        private CollectorListVariable m_ListVariable = new CollectorListVariable();
        protected override Task Run(Args args)
        {
            List<object> elements = this.m_ListVariable.Get;
            int index1 = 0;

            object value1 = elements[index1];

            elements.Add(value1);
            elements.RemoveAt(index1);

            this.m_ListVariable.Fill(elements.ToArray());

            return DefaultResult;
        }
    }
}