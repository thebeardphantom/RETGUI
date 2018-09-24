using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// A clickable button
    /// </summary>
    public class ButtonWidget : Widget<ButtonWidget>
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
        public ButtonWidget() { }

        /// <inheritdoc />
        public ButtonWidget(DrawCallback<ButtonWidget> initializer) : base(initializer) { }

        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            if(GUI.Button(rect, Label, ActiveStyle))
            {
                ButtonClickedEvent?.Invoke(this, Event.current);
            }
        }

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            DefaultStyle = GUI.skin.button.Duplicate();
        }
    }
}