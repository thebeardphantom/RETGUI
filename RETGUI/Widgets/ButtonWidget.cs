using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// A clickable button
    /// </summary>
    public class ButtonWidget : Widget
    {
        /// <summary>
        /// Method signature for responding to button click events
        /// </summary>
        public delegate void ButtonClicked(ButtonWidget button, Event evt);

        /// <summary>
        /// Event fired when button is clicked
        /// </summary>
        public event ButtonClicked ButtonClickedEvent;

        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            if(GUI.Button(rect, Label, ActiveStyle))
            {
                ButtonClickedEvent?.Invoke(this, Event.current);
            }
        }

        /// <inheritdoc />
        protected override GUIStyle GetDefaultStyle()
        {
            return GUI.skin.button;
        }
    }
}