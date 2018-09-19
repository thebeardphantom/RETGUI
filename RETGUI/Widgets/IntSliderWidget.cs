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
        protected override void DrawInternal(Rect rect)
        {
            Value = EditorGUI.IntSlider(rect, Label, Value, MinValue, MaxValue);
        }

        /// <inheritdoc />
        protected override GUIStyle GetDefaultStyle()
        {
            return GUI.skin.horizontalSlider;
        }
    }
}