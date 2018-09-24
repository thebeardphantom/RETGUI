using UnityEditor;
using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// A simple integer field
    /// </summary>
    public class IntFieldWidget : NumberFieldWidget<IntFieldWidget, int>
    {
        /// <inheritdoc />
        public IntFieldWidget() { }

        /// <inheritdoc />
        public IntFieldWidget(DrawCallback<IntFieldWidget> initializer) : base(initializer) { }

        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            var newValue = EditorGUI.IntField(rect, Label, Value, ActiveStyle);
            SetValue(newValue);
        }
    }
}