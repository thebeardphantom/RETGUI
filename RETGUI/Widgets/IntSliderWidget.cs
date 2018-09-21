using UnityEditor;
using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// Displays an int slider with min/max values
    /// </summary>
    public class IntSliderWidget : ValueWidget<int>
    {
        /// <summary>
        /// Minimum value
        /// </summary>
        public int MinValue;

        /// <summary>
        /// Maximum value
        /// </summary>
        public int MaxValue;

        /// <inheritdoc />
        public IntSliderWidget() { }

        /// <inheritdoc />
        public IntSliderWidget(DrawCallback initializer) : base(initializer) { }

        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            var newValue = EditorGUI.IntSlider(rect, Label, Value, MinValue, MaxValue);
            SetValue(newValue);
        }

        protected override void OnInitialize()
        {
            DefaultStyle = GUI.skin.horizontalSlider.Duplicate();
        }
    }
}