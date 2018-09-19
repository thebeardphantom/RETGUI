using System;
using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// A clickable button
    /// </summary>
    public class ButtonWidget : Widget
    {
        /// <summary>
        /// Callback when button is clicked
        /// </summary>
        public Action Clicked;

        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            if(GUI.Button(rect, Label, ActiveStyle))
            {
                Clicked?.Invoke();
            }
        }

        /// <inheritdoc />
        protected override GUIStyle GetDefaultStyle()
        {
            return GUI.skin.button;
        }
    }
}