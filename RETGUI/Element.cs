using System;
using UnityEngine;

namespace BeardPhantom.RETGUI
{
    /// <summary>
    /// The most basic unit of UI.
    /// </summary>
    public abstract class Element
    {
        /// <summary>
        /// Style to use for rendering
        /// </summary>
        public GUIStyle StyleOverride;

        /// <summary>
        /// Colors used for rendering this element
        /// </summary>
        public ColorSet Colors = new ColorSet();

        /// <summary>
        /// Id for querying elements
        /// </summary>
        public string Id = Guid.NewGuid().ToString();

        /// <summary>
        /// Whether GUI is enabled for this element
        /// </summary>
        public bool Enabled = true;

        /// <summary>
        /// The current style, or the override
        /// </summary>
        public GUIStyle ActiveStyle => StyleOverride ?? GetDefaultStyle();

        /// <summary>
        /// Draw using autolayout
        /// </summary>
        public void Draw()
        {
            var enabled = GUI.enabled;
            var color = GUI.color;
            var backgroundColor = GUI.backgroundColor;
            var contentColor = GUI.contentColor;

            GUI.enabled = enabled && Enabled;
            GUI.color = Colors.Color;
            GUI.backgroundColor = Colors.BackgroundColor;
            GUI.contentColor = Colors.ContentColor;

            DrawInternal();

            GUI.contentColor = contentColor;
            GUI.backgroundColor = backgroundColor;
            GUI.color = color;
            GUI.enabled = enabled;
        }

        /// <summary>
        /// Draw using rect
        /// </summary>
        public void Draw(Rect rect)
        {
            var enabled = GUI.enabled;
            var color = GUI.color;
            var backgroundColor = GUI.backgroundColor;
            var contentColor = GUI.contentColor;

            GUI.enabled = enabled && Enabled;
            GUI.color = Colors.Color;
            GUI.backgroundColor = Colors.BackgroundColor;
            GUI.contentColor = Colors.ContentColor;

            DrawInternal(rect);

            GUI.contentColor = contentColor;
            GUI.backgroundColor = backgroundColor;
            GUI.color = color;
            GUI.enabled = enabled;
        }

        /// <summary>
        /// Internal draw function using autolayout
        /// </summary>
        protected abstract void DrawInternal();

        /// <summary>
        /// Internal draw function using a rect
        /// </summary>
        protected abstract void DrawInternal(Rect rect);

        /// <summary>
        /// The default style to use for rendering
        /// </summary>
        protected abstract GUIStyle GetDefaultStyle();

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{GetType().Name} | ID:{Id} | Enabled:{Enabled}";
        }
    }
}