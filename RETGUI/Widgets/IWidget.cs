namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// Base widget implementation
    /// </summary>
    public interface IWidget : IElement
    {
        /// <summary>
        /// Calculates the height of this widget
        /// </summary>
        float CalcHeight();
    }
}