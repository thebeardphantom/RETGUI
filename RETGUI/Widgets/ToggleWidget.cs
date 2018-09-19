using UnityEditor;
using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// A simple toggle
    /// </summary>
    public class ToggleWidget : ValueWidget<bool>
    {
        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            Value = EditorGUI.Toggle(rect, Label, Value, ActiveStyle);
        }

        /// <inheritdoc />
        protected override GUIStyle GetDefaultStyle()
        {
            return EditorStyles.toggle;
        }
    }
}