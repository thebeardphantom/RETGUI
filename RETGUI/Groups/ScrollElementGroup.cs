using UnityEditor;
using UnityEngine;

namespace BeardPhantom.RETGUI.Groups
{
    /// <summary>
    /// A group of elements in a scroll view
    /// </summary>
    public class ScrollElementGroup : ElementGroup<ScrollElementGroup>
    {
        /// <summary>
        /// Current position in scroll
        /// </summary>
        public Vector2 ScrollPosition;

        /// <summary>
        /// Always show horizontal scrollbar?
        /// </summary>
        public bool AlwaysShowHorizontal;

        /// <summary>
        /// Always show vertical scrollbar?
        /// </summary>
        public bool AlwaysShowVertical;

        /// <inheritdoc />
        public ScrollElementGroup() { }

        /// <inheritdoc />
        public ScrollElementGroup(DrawCallback<ScrollElementGroup> initializer) : base(initializer) { }

        /// <inheritdoc />
        public ScrollElementGroup(params IElement[] elements) : base(elements) { }

        /// <inheritdoc />
        public ScrollElementGroup(DrawCallback<ScrollElementGroup> initializer, params IElement[] elements) : base(initializer, elements) { }

        /// <inheritdoc />
        protected override void DrawInternal()
        {
            using(var scope = new EditorGUILayout.ScrollViewScope(ScrollPosition, AlwaysShowHorizontal, AlwaysShowVertical))
            {
                ScrollPosition = scope.scrollPosition;
                foreach(var element in Elements)
                {
                    element.Draw();
                }
            }
        }
    }
}