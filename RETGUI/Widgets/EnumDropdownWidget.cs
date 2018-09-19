using System;
using UnityEditor;
using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// Displays a dropdown to select an enum value of type <see cref="T" />
    /// </summary>
    public class EnumDropdownWidget<T> : ValueWidget<T> where T : struct, IComparable, IFormattable, IConvertible
    {
        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            var newValue = EditorGUI.EnumPopup(rect, Label, Value as Enum, ActiveStyle);
            Value = (T) (object) newValue;
        }

        /// <inheritdoc />
        protected override GUIStyle GetDefaultStyle()
        {
            return EditorStyles.popup;
        }
    }
}