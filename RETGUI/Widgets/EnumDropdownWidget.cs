using System;
using UnityEditor;
using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// Displays a dropdown to select an enum value of type <see cref="T" />
    /// </summary>
    public class EnumDropdownWidget<T> : ValueWidget<EnumDropdownWidget<T>, T> where T : struct, IComparable, IFormattable, IConvertible
    {
        /// <inheritdoc />
        public EnumDropdownWidget() { }

        /// <inheritdoc />
        public EnumDropdownWidget(DrawCallback<EnumDropdownWidget<T>> initializer) : base(initializer) { }

        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            var newValue = EditorGUI.EnumPopup(rect, Label, Value as Enum, ActiveStyle);
            SetValue((T) (object) newValue);
        }

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            DefaultStyle = EditorStyles.popup.Duplicate();
        }
    }
}