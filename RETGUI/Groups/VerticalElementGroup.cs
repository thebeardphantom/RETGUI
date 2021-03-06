﻿using UnityEditor;

namespace BeardPhantom.RETGUI.Groups
{
    /// <summary>
    /// A vertical group of elements
    /// </summary>
    public class VerticalElementGroup : ElementGroup<VerticalElementGroup>
    {
        /// <summary>
        /// A group with no elements
        /// </summary>
        public VerticalElementGroup() { }

        /// <summary>
        /// A group with elements to start
        /// </summary>
        public VerticalElementGroup(params IElement[] elements) : base(elements) { }

        /// <inheritdoc />
        public VerticalElementGroup(DrawCallback<VerticalElementGroup> initializer) : base(initializer) { }

        /// <inheritdoc />
        public VerticalElementGroup(DrawCallback<VerticalElementGroup> initializer, params IElement[] elements)
            : base(initializer, elements) { }

        /// <inheritdoc />
        protected override void DrawInternal()
        {
            using(new EditorGUILayout.VerticalScope(ActiveStyle))
            {
                foreach(var element in Elements)
                {
                    element.Draw();
                }
            }
        }
    }
}