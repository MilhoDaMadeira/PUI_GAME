using GameCreator.Editor.Common;
using GameCreator.Runtime.Transitions;
using UnityEditor;
using UnityEngine.UIElements;

namespace GameCreator.Editor.Transitions
{
    [CustomEditor(typeof(Transient))]
    public class TransientEditor : UnityEditor.Editor
    {
        // PAINT METHOD: --------------------------------------------------------------------------
        
        public override VisualElement CreateInspectorGUI()
        {
            VisualElement content = new VisualElement();

            SerializedProperty value = this.serializedObject.FindProperty("m_Value");
            SerializedProperty decimals = this.serializedObject.FindProperty("m_Decimals");
            SerializedProperty progress = this.serializedObject.FindProperty("m_Progress");
            
            SerializedProperty activeIfOpen = this.serializedObject.FindProperty("m_ActiveIfOpen");
            SerializedProperty activeIfReady = this.serializedObject.FindProperty("m_ActiveIfReady");
            
            content.Add(new PropertyTool(value));
            content.Add(new PropertyTool(decimals));
            
            content.Add(new SpaceSmall());
            content.Add(new PropertyTool(progress));
            
            content.Add(new SpaceSmall());
            content.Add(new PropertyTool(activeIfOpen));
            content.Add(new PropertyTool(activeIfReady));

            return content;
        }
    }
}