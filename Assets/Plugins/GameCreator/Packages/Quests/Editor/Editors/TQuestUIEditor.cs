using GameCreator.Editor.Common;
using GameCreator.Runtime.Quests.UnityUI;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameCreator.Editor.Quests
{
    public abstract class TQuestUIEditor : UnityEditor.Editor
    {
        private const string ERR_PREFAB = "Task Prefab does not contain a 'Task UI' component";

        protected abstract string Message { get; }
        
        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = new VisualElement();

            InfoMessage info = new InfoMessage(this.Message);
            root.Add(info);

            this.CreateAdditionalProperties(root);

            SerializedProperty title = this.serializedObject.FindProperty("m_Title");
            SerializedProperty description = this.serializedObject.FindProperty("m_Description");
            SerializedProperty color = this.serializedObject.FindProperty("m_Color");
            SerializedProperty sprite = this.serializedObject.FindProperty("m_Sprite");
            
            root.Add(new SpaceSmall());
            root.Add(new PropertyTool(title));
            root.Add(new SpaceSmaller());
            root.Add(new PropertyTool(description));
            root.Add(new SpaceSmaller());
            root.Add(new PropertyTool(color));
            root.Add(new SpaceSmaller());
            root.Add(new PropertyTool(sprite));
            
            SerializedProperty styleGraphics = this.serializedObject.FindProperty("m_StyleGraphics");
            SerializedProperty activeElements = this.serializedObject.FindProperty("m_ActiveElements");
            SerializedProperty interactions = this.serializedObject.FindProperty("m_Interactions");

            root.Add(new SpaceSmall());
            root.Add(new PropertyField(styleGraphics));
            root.Add(new PropertyField(activeElements));
            root.Add(new PropertyField(interactions));
            
            root.Add(new SpaceSmall());
            root.Add(new LabelTitle("Tasks:"));

            SerializedProperty show = this.serializedObject.FindProperty("m_Show");
            SerializedProperty showHidden = this.serializedObject.FindProperty("m_ShowHidden");
            
            root.Add(new SpaceSmaller());
            root.Add(new PropertyTool(show));
            root.Add(new PropertyTool(showHidden));
            
            SerializedProperty tasksContent = this.serializedObject.FindProperty("m_TasksContent");
            SerializedProperty taskPrefab = this.serializedObject.FindProperty("m_TaskPrefab");

            PropertyTool fieldTasksContent = new PropertyTool(tasksContent);
            ErrorMessage fieldErrorTaskPrefab = new ErrorMessage(ERR_PREFAB);
            PropertyTool fieldTaskPrefab = new PropertyTool(taskPrefab);
            
            root.Add(new SpaceSmaller());
            root.Add(fieldTasksContent);
            root.Add(fieldErrorTaskPrefab);
            root.Add(fieldTaskPrefab);

            fieldTaskPrefab.EventChange += changeEvent =>
            {
                GameObject prefab = changeEvent.changedProperty.objectReferenceValue as GameObject;
                fieldErrorTaskPrefab.style.display =
                    prefab != null && prefab.GetComponent<TaskUI>() == null
                        ? DisplayStyle.Flex
                        : DisplayStyle.None;
            };
            
            GameObject prefab = taskPrefab.objectReferenceValue as GameObject;
            fieldErrorTaskPrefab.style.display =
                prefab != null && prefab.GetComponent<TaskUI>() == null
                    ? DisplayStyle.Flex
                    : DisplayStyle.None;

            return root;
        }

        protected virtual void CreateAdditionalProperties(VisualElement root)
        { }
    }
}