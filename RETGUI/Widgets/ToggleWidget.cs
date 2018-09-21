﻿using UnityEditor;
using UnityEngine;

namespace BeardPhantom.RETGUI.Widgets
{
    /// <summary>
    /// A simple toggle
    /// </summary>
    public class ToggleWidget : ValueWidget<bool>
    {
        /// <inheritdoc />
        public ToggleWidget() { }

        /// <inheritdoc />
        public ToggleWidget(DrawCallback initializer) : base(initializer) { }

        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            var newValue = EditorGUI.Toggle(rect, Label, Value, ActiveStyle);
            SetValue(newValue);
        }

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            DefaultStyle = EditorStyles.toggle.Duplicate();
        }
    }
}