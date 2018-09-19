using UnityEditor;
using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// A widget for displaying a number field
    /// </summary>
    public abstract class NumberFieldWidget<T> : ValueWidget<T> where T : struct
    {
        /// <inheritdoc />
        protected override GUIStyle GetDefaultStyle()
        {
            return EditorStyles.numberField;
        }
    }
}