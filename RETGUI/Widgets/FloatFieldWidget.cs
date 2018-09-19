using UnityEditor;
using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// A simple float field
    /// </summary>
    public class FloatFieldWidget : NumberFieldWidget<float>
    {
        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            Value = EditorGUI.FloatField(rect, Label, Value, ActiveStyle);
        }
    }
}