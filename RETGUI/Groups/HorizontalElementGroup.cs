using UnityEditor;

namespace BeardPhantom.RETGUI.Groups
{
    /// <summary>
    /// A horizontal group of elements in a layout
    /// </summary>
    public class HorizontalElementGroup : ElementGroup
    {
        /// <summary>
        /// A horizontal group with no elements
        /// </summary>
        public HorizontalElementGroup() { }

        /// <summary>
        /// A horizontal group with elements to start
        /// </summary>
        /// <param name="elements"></param>
        public HorizontalElementGroup(params Element[] elements) : base(elements) { }

        /// <inheritdoc />
        protected override void DrawElementsInternal()
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