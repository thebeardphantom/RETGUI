using UnityEditor;
using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// Simple one to two label widget
    /// </summary>
    public class LabelWidget : ValueWidget<string>
    {
        /// <inheritdoc />
        public LabelWidget() { }

        /// <inheritdoc />
        public LabelWidget(DrawCallback initializer) : base(initializer) { }

        /// <inheritdoc />
        public override float CalcHeight()
        {
            return ActiveStyle.CalcSize(new GUIContent(Value)).y;
        }

        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            if(HasLabel)
            {
                EditorGUI.LabelField(rect, Label, Value, ActiveStyle);
            }
            else
            {
                EditorGUI.LabelField(rect, Value, ActiveStyle);
            }
        }

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            DefaultStyle = EditorStyles.label.Duplicate();
        }
    }
}