﻿using UnityEditor;

namespace BeardPhantom.RETGUI.Groups
{
    /// <summary>
    /// A vertical group of elements
    /// </summary>
    public class VerticalElementGroup : ElementGroup
    {
        /// <summary>
        /// A group with no elements
        /// </summary>
        public VerticalElementGroup() { }

        /// <summary>
        /// A group with elements to start
        /// </summary>
        public VerticalElementGroup(params Element[] elements) : base(elements) { }

        /// <inheritdoc />
        protected override void DrawElementsInternal()
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