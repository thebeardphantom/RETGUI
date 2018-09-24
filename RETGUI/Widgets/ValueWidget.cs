namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// A widget that manipulates a value
    /// </summary>
    public abstract class ValueWidget<T, V> : Widget<T> where T : ValueWidget<T, V>
    {
        /// <summary>
        /// Function for responding to value changes
        /// </summary>
        public delegate void ValueChanged(V oldValue, V newValue);

        /// <summary>
        /// Event fired when value is updated
        /// </summary>
        public event ValueChanged ValueChangedEvent;

        /// <summary>
        /// Underlying widget value
        /// </summary>
        public V Value { get; private set; }

        /// <inheritdoc />
        protected ValueWidget() { }

        /// <inheritdoc />
        protected ValueWidget(DrawCallback<T> initializer) : base(initializer) { }

        /// <summary>
        /// Implicitly convert to value
        /// </summary>
        public static implicit operator V(ValueWidget<T, V> widget)
        {
            return widget.Value;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{base.ToString()} | Value:{Value}";
        }

        /// <summary>
        /// Sets value, optionally firing update event
        /// </summary>
        public void SetValue(V value, bool silent = false)
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
    }
}