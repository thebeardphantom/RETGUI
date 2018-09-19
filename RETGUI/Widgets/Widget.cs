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

        /// <summary>
        /// Is there a label set?
        /// </summary>
        public bool HasLabel => !string.IsNullOrWhiteSpace(Label);

        /// <inheritdoc />
        protected override void DrawInternal()
        {
            var rect = EditorGUILayout.GetControlRect(HasLabel, CalcHeight(), ActiveStyle);
            DrawInternal(rect);
        }

        /// <summary>
        /// Calculates the height of this widget
        /// </summary>
        public virtual float CalcHeight()
        {
            return ActiveStyle.CalcSize(HasLabel ? new GUIContent(Label) : _defaultText).y;
        }
    }
}