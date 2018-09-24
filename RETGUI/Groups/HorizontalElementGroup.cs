using UnityEditor;

namespace BeardPhantom.RETGUI.Groups
{
    /// <summary>
    /// A horizontal group of elements in a layout
    /// </summary>
    public class HorizontalElementGroup : ElementGroup<HorizontalElementGroup>
    {
        /// <inheritdoc />
        public HorizontalElementGroup() { }

        /// <inheritdoc />
        public HorizontalElementGroup(params IElement[] elements) : base(elements) { }

        /// <inheritdoc />
        public HorizontalElementGroup(DrawCallback<HorizontalElementGroup> initializer) : base(initializer) { }

        /// <inheritdoc />
        public HorizontalElementGroup(DrawCallback<HorizontalElementGroup> initializer, params IElement[] elements) :
            base(initializer, elements) { }

        /// <inheritdoc />
        protected override void DrawInternal()
        {
            using(new EditorGUILayout.HorizontalScope(ActiveStyle))
            {
                foreach(var element in Elements)
                {
                    element.Draw();
                }
            }
        }
    }
}