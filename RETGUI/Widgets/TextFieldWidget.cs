using UnityEditor;
using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// A widget that shows a text field
    /// </summary>
    public class TextFieldWidget : ValueWidget<TextFieldWidget, string>
    {
        /// <inheritdoc />
        public TextFieldWidget() { }

        /// <inheritdoc />
        public TextFieldWidget(DrawCallback<TextFieldWidget> initializer) : base(initializer) { }

        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            var newValue = HasLabel
                ? EditorGUI.TextField(rect, Label, Value, ActiveStyle)
                : EditorGUI.TextField(rect, Value, ActiveStyle);
            SetValue(newValue);
        }

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            DefaultStyle = EditorStyles.textField;
        }
    }
}