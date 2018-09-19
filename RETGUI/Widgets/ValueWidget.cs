namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// A widget that manipulates a value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValueWidget<T> : Widget
    {
        /// <summary>
        /// Underlying widget value
        /// </summary>
        public T Value;

        /// <summary>
        /// Implicitly convert to value
        /// </summary>
        public static implicit operator T(ValueWidget<T> widget)
        {
            return widget.Value;
        }
    }
}