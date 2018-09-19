using UnityEditor;
using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// A simple integer field
    /// </summary>
    public class IntFieldWidget : NumberFieldWidget<int>
    {
        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            Value = EditorGUI.IntField(rect, Label, Value, ActiveStyle);
        }
    }
}