using System;
using UnityEditor;
using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// An enum mask field
    /// </summary>
    public class EnumFlagsDropdownWidget<T> : ValueWidget<T> where T : struct, IComparable, IFormattable, IConvertible
    {
        /// <inheritdoc />
        public EnumFlagsDropdownWidget() { }

        /// <inheritdoc />
        public EnumFlagsDropdownWidget(DrawCallback initializer) : base(initializer) { }

        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            var newValue = HasLabel
                ? EditorGUI.EnumFlagsField(rect, Label, (Enum) Enum.ToObject(typeof(T), Value), ActiveStyle)
                : EditorGUI.EnumFlagsField(rect, (Enum) Enum.ToObject(typeof(T), Value), ActiveStyle);
            SetValue((T) (object) newValue);
        }

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            DefaultStyle = EditorStyles.popup;
        }
    }
}