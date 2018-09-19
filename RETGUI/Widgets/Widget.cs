using UnityEditor;
using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// An individual control in the UI
    /// </summary>
    public abstract class Widget : Element
    {
        /// <summary>
        /// Debug text for measuring the widget's height
        /// </summary>
        private static readonly GUIContent _defaultText = new GUIContent("Default Text");

        /// <summary>
        /// An optional prefix label
        /// </summary>
        public string Label;

        /// <inheritdoc />
        public override void Draw()
        {
            var hasLabel = string.IsNullOrWhiteSpace(Label);
            var rect = EditorGUILayout.GetControlRect(hasLabel, CalcHeight(), ActiveStyle);
            Draw(rect);
        }

        /// <summary>
        /// Calculates the height of this widget
        /// </summary>
        public virtual float CalcHeight()
        {
            return ActiveStyle.CalcSize(_defaultText).y;
        }

        /// <summary>
        /// Draws this widget inside a given rect
        /// </summary>
        public void Draw(Rect rect)
        {
            var enabled = GUI.enabled;
            GUI.enabled = enabled && Enabled;
            DrawInternal(rect);
            GUI.enabled = enabled;
        }

        /// <summary>
        /// Draw contents of widget in rect
        /// </summary>
        protected abstract void DrawInternal(Rect rect);
    }
}