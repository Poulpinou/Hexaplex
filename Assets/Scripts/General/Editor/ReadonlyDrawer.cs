using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Hexaplex.Editor {
    [CustomPropertyDrawer(typeof(ReadonlyAttribute))]
    public class ReadonlyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Debug.Log(property.propertyType);
            switch (property.propertyType)
            {
                case SerializedPropertyType.Integer:
                    GUI.Label(position, label.text + " : " + property.intValue.ToString());
                    break;
                case SerializedPropertyType.Boolean:
                    GUI.Label(position, label.text + " : " + (property.boolValue ? "True" : "False"));
                    break;
                case SerializedPropertyType.Float:
                    GUI.Label(position, label.text + " : " + property.floatValue.ToString());
                    break;
                case SerializedPropertyType.String:
                    GUI.Label(position, label.text + " : " + property.stringValue);
                    break;
                case SerializedPropertyType.Enum:
                    GUI.Label(position, label.text + " : " + property.enumNames[property.enumValueIndex]);
                    break;
                case SerializedPropertyType.Vector2Int:
                    GUI.Label(position, label.text + " : " + property.vector2Value.ToString());
                    break;
                case SerializedPropertyType.Vector3Int:
                    GUI.Label(position, label.text + " : " + property.vector3Value.ToString());
                    break;
                case SerializedPropertyType.Vector2:
                    GUI.Label(position, label.text + " : " + property.vector2Value.ToString());
                    break;
                case SerializedPropertyType.Vector3:
                    GUI.Label(position, label.text + " : " + property.vector3Value.ToString());
                    break;
                case SerializedPropertyType.Vector4:
                    GUI.Label(position, label.text + " : " + property.vector4Value.ToString());
                    break;
                case SerializedPropertyType.ExposedReference:
                    GUI.Label(position, label.text + " : " + (property.exposedReferenceValue?.ToString() ?? "None"));
                    break;
                case SerializedPropertyType.ObjectReference:
                    GUI.Label(position, label.text + " : " +(property.objectReferenceValue?.ToString() ?? "None"));
                    break;

                // Other cases as default (Todo: add an implementation for each... Lol.)
                // (draws the property field by default, but prevent edition)
                case SerializedPropertyType.Color:
                case SerializedPropertyType.LayerMask:
                case SerializedPropertyType.Rect:
                case SerializedPropertyType.ArraySize:
                case SerializedPropertyType.Character:
                case SerializedPropertyType.AnimationCurve:
                case SerializedPropertyType.Bounds:
                case SerializedPropertyType.Gradient:
                case SerializedPropertyType.Quaternion:
                case SerializedPropertyType.FixedBufferSize:
                case SerializedPropertyType.RectInt:
                case SerializedPropertyType.BoundsInt:
                case SerializedPropertyType.ManagedReference:
                case SerializedPropertyType.Generic:
                default:
                    GUI.enabled = false;
                    EditorGUI.PropertyField(position, property, label, true);
                    GUI.enabled = true;
                    break;
            }
        }
    }
}