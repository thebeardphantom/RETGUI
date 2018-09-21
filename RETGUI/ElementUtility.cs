using UnityEngine;

namespace BeardPhantom.RETGUI
{
    /// <summary>
    /// Various utility functions for elements
    /// </summary>
    public static class ElementUtility
    {
        /// <summary>
        /// Duplicates a style
        /// </summary>
        public static GUIStyle Duplicate(this GUIStyle style)
        {
            return new GUIStyle(style);
        }
    }
}