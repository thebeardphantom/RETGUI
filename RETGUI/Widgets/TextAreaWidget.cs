using UnityEditor;
using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// A widget that shows a text area
    /// </summary>
    public class TextAreaWidget : ValueWidget<string>
    {
        /// <inheritdoc />
        public TextAreaWidget() { }

        /// <inheritdoc />
        public TextAreaWidget(DrawCallback initializer) : base(initializer) { }

        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            var newValue = EditorGUI.TextArea(rect, Value, ActiveStyle);
            SetValue(newValue);
        }

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            DefaultStyle = EditorStyles.textArea.Duplicate();
        }
    }
}