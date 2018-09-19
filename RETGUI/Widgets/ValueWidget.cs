namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// A widget that manipulates a value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValueWidget<T> : Widget
    {
        /// <summary>
        /// Function for responding to value changes
        /// </summary>
        public delegate void ValueChanged(T oldValue, T newValue);

        /// <summary>
        /// Event fired when value is updated
        /// </summary>
        public event ValueChanged ValueChangedEvent;

        /// <summary>
        /// Underlying widget value
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Sets value, optionally firing update event
        /// </summary>
        public void SetValue(T value, bool silent = false)
        {
            if(!Equals(Value, value))
            {
                var oldValue = Value;
                Value = value;
                if(!silent)
                {
                    ValueChangedEvent?.Invoke(oldValue, value);
                }
            }
        }

        /// <summary>
        /// Implicitly convert to value
        /// </summary>
        public static implicit operator T(ValueWidget<T> widget)
        {
            return widget.Value;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Value:{Value}";
        }
    }
}