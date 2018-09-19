using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BeardPhantom.RETGUI.Groups
{
    /// <summary>
    /// A group of elements in a layout
    /// </summary>
    public abstract class ElementGroup : Element
    {
        /// <summary>
        /// All elements under this group
        /// </summary>
        public readonly List<Element> Elements = new List<Element>();

        /// <summary>
        /// A group with no elements
        /// </summary>
        protected ElementGroup() { }

        /// <summary>
        /// A group with elements to start
        /// </summary>
        protected ElementGroup(params Element[] elements)
        {
            Elements.AddRange(elements);
        }

        /// <inheritdoc />
        public override void Draw()
        {
            var enabled = GUI.enabled;
            GUI.enabled = enabled && Enabled;
            DrawElementsInternal();
            GUI.enabled = enabled;
        }

        /// <summary>
        /// Finds an element by its id
        /// </summary>
        public T FindElementById<T>(string id) where T : Element
        {
            return (T)Elements.SingleOrDefault(element => element.Id == id);
        }

        /// <summary>
        /// Adds elements to group
        /// </summary>
        public void AddElements(params Element[] elements)
        {
            Elements.AddRange(elements);
        }

        /// <summary>
        /// Removes elements from group
        /// </summary>
        public void RemoveElements(params Element[] elements)
        {
            foreach(var element in elements)
            {
                Elements.Remove(element);
            }
        }

        /// <inheritdoc />
        protected override GUIStyle GetDefaultStyle()
        {
            return GUIStyle.none;
        }

        /// <summary>
        /// Draw all contained elements
        /// </summary>
        protected abstract void DrawElementsInternal();
    }
}