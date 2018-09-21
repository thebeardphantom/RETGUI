using UnityEditor;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// A widget for displaying a number field
    /// </summary>
    public abstract class NumberFieldWidget<T> : ValueWidget<T> where T : struct
    {
        /// <inheritdoc />
        protected NumberFieldWidget() { }

        /// <inheritdoc />
        protected NumberFieldWidget(DrawCallback initializer) : base(initializer) { }

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            DefaultStyle = EditorStyles.numberField.Duplicate();
        }
    }
}