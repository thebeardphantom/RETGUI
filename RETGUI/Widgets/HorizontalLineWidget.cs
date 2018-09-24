using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// A horizontal line
    /// </summary>
    public class HorizontalLineWidget : Widget<HorizontalLineWidget>
    {
        /// <inheritdoc />
        public HorizontalLineWidget() { }

        /// <inheritdoc />
        public HorizontalLineWidget(DrawCallback<HorizontalLineWidget> initializer) : base(initializer) { }

        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            GUI.Label(rect, GUIContent.none, ActiveStyle);
        }

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            DefaultStyle = GUI.skin.horizontalSlider.Duplicate();
        }
    }
}