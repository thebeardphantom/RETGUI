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
        /// Id for querying elements
        /// </summary>
        public string Id = System.Guid.NewGuid().ToString();

        /// <summary>
        /// Whether GUI is enabled for this element
        /// </summary>
        public bool Enabled = true;

        /// <summary>
        /// The current style, or the override
        /// </summary>
        public GUIStyle ActiveStyle => StyleOverride ?? GetDefaultStyle();

        /// <summary>
        /// Draws the element
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// The default style to use for rendering
        /// </summary>
        protected abstract GUIStyle GetDefaultStyle();
    }
}