using System;
using UnityEngine;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using System.Collections.Generic;

namespace GameCreator.Runtime.VisualScripting
{
    [Version(1, 0, 0)]
    [Title("Cycle List Reversed")]
    [Description("Moves the last element of a list to the first of the list")]

    [Image(typeof(IconRepeat), ColorTheme.Type.Teal, typeof(OverlayListVariable))]

    [Category("Variables/Cycle List Reversed")]

    [Parameter("List Variable", "Local List or Global List for which elements are cycled")]

    [Keywords("Order", "Change", "Array", "List", "Variables", "Loop", "Cycle")]
    [Serializable]
    public class CycleListReversed : Instruction
    {
        public override string Title => $"Cycle elements on {this.m_ListVariable}";

        [SerializeField]
        private CollectorListVariable m_ListVariable = new CollectorListVariable();
        protected override Task Run(Args args)
        {
            List<object> elements = this.m_ListVariable.Get;
            // int index1 = 0;
            int lastIndex = elements.Count - 1;

            object value1 = elements[lastIndex];

            elements.Insert(0, value1);
            elements.RemoveAt(elements.Count - 1);

            this.m_ListVariable.Fill(elements.ToArray());

            return DefaultResult;
        }
    }
}