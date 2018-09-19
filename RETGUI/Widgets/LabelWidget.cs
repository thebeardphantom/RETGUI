using UnityEditor;
using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// Simple one to two label widget
    /// </summary>
    public class LabelWidget : Widget
    {
        /// <summary>
        /// Optional secondary data
        /// </summary>
        public string Label2;

        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            EditorGUI.LabelField(rect, Label, Label2, ActiveStyle);
        }

        /// <inheritdoc />
        protected override GUIStyle GetDefaultStyle()
        {
            return EditorStyles.label;
        }
    }
}