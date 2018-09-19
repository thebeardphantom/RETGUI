using UnityEditor;
using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// Simple one to two label widget
    /// </summary>
    public class LabelWidget : ValueWidget<string>
    {
        /// <summary>
        /// Is word wrapping enabled
        /// </summary>
        public bool WordWrap;

        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            var wrapping = ActiveStyle.wordWrap;
            ActiveStyle.wordWrap = WordWrap;
            if(HasLabel)
            {
                EditorGUI.LabelField(rect, Label, Value, ActiveStyle);
            }
            else
            {
                EditorGUI.LabelField(rect, Value, ActiveStyle);
            }
            ActiveStyle.wordWrap = wrapping;
        }

        public override float CalcHeight()
        {
            return ActiveStyle.CalcSize(new GUIContent(Value)).y;
        }

        /// <inheritdoc />
        protected override GUIStyle GetDefaultStyle()
        {
            return EditorStyles.label;
        }
    }
}