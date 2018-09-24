using UnityEditor;
using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// A simple float field
    /// </summary>
    public class FloatFieldWidget : NumberFieldWidget<FloatFieldWidget, float>
    {
        /// <inheritdoc />
        public FloatFieldWidget() { }

        /// <inheritdoc />
        public FloatFieldWidget(DrawCallback<FloatFieldWidget> initializer) : base(initializer) { }

        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            var newValue = EditorGUI.FloatField(rect, Label, Value, ActiveStyle);
            SetValue(newValue);
        }
    }
}