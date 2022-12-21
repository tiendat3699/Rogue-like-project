using UnityEngine;
using UnityEditor;

namespace MyCustomAttribute
{
    [CustomPropertyDrawer( typeof( ReadOnlyAttribute ) )]
    public class ReadOnlyDrawer : PropertyDrawer {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            // accounts for foldouts on serialized classes
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // disables elements in the gui
            GUI.enabled = false;
            // creates the property, which will be disabled because of the above line
            EditorGUI.PropertyField(position, property, new GUIContent(label + "(read only)"), true);
            // re-enables the gui so that not all properties are greyed out
            GUI.enabled = true;
        }

    }
}

