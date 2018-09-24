using UnityEditor;
using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// An individual control in the UI
    /// </summary>
    public abstract class Widget<T> : Element<T>, IWidget where T : Widget<T>
    {
        /// <summary>
        /// Debug text for measuring the widget's height
        /// </summary>
        private static readonly GUIContent _defaultText = new GUIContent("Default Text");

        /// <summary>
        /// An optional prefix label
        /// </summary>
        public GUIContent Label;

        /// <summary>
        /// Fixed height value to use instead of calculating one
        /// </summary>
        public float Height = -1;

        /// <summary>
        /// Fixed width value to use instead of calculating one
        /// </summary>
        public float Width = -1;

        /// <summary>
        /// Is there a label set?
        /// </summary>
        public bool HasLabel => Label != null && !string.IsNullOrWhiteSpace(Label.text);

        /// <inheritdoc />
        protected Widget(DrawCallback<T> initializer) : base(initializer) { }

        /// <inheritdoc />
        protected Widget() { }

        /// <summary>
        /// Calculates the height of this widget
        /// </summary>
        public virtual float CalcHeight()
        {
            return Height >= 0f ? Height : ActiveStyle.CalcSize(HasLabel ? new GUIContent(Label) : _defaultText).y;
        }

        /// <inheritdoc />
        protected override void DrawInternal()
        {
            var rect = EditorGUILayout.GetControlRect(HasLabel, CalcHeight(), ActiveStyle);
            rect.width = Width >= 0f ? Width : rect.width;
            DrawInternal(rect);
        }
    }
}