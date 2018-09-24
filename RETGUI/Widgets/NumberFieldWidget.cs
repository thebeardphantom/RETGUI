using UnityEditor;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// A widget for displaying a number field
    /// </summary>
    public abstract class NumberFieldWidget<T, V> : ValueWidget<T, V> where T : NumberFieldWidget<T, V> where V : struct
    {
        /// <inheritdoc />
        protected NumberFieldWidget() { }

        /// <inheritdoc />
        protected NumberFieldWidget(DrawCallback<T> initializer) : base(initializer) { }

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            DefaultStyle = EditorStyles.numberField.Duplicate();
        }
    }
}