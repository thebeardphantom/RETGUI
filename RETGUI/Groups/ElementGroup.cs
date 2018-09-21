using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        /// <inheritdoc />
        protected ElementGroup() { }

        /// <inheritdoc />
        protected ElementGroup(DrawCallback initializer) : base(initializer) { }

        /// <summary>
        /// A group with elements to start
        /// </summary>
        protected ElementGroup(params Element[] elements)
        {
            Elements.AddRange(elements);
        }

        /// <summary>
        /// A group with elements to start
        /// </summary>
        protected ElementGroup(DrawCallback initializer, params Element[] elements) : base(initializer)
        {
            Elements.AddRange(elements);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder();
            var depth = new Stack<int>();
            var items = new Stack<Element>();
            depth.Push(0);
            items.Push(this);
            while(items.Count > 0)
            {
                var depthVal = depth.Pop();
                var current = items.Pop();
                for(var i = 0; i < depthVal; i++)
                {
                    sb.Append('\t');
                }
                if(current is ElementGroup group)
                {
                    sb.AppendLine(group.GetElementDebugString());
                    for(var i = group.Elements.Count - 1; i >= 0; i--)
                    {
                        var element = group.Elements[i];
                        depth.Push(depthVal + 1);
                        items.Push(element);
                    }
                }
                else
                {
                    sb.AppendLine(current.ToString());
                }
            }
            return sb.ToString().Trim();
        }

        /// <summary>
        /// Finds an element by its id
        /// </summary>
        public T FindElementById<T>(string id) where T : Element
        {
            return (T) Elements.SingleOrDefault(element => element.Id == id);
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
        protected override void DrawInternal(Rect rect)
        {
            using(new GUILayout.AreaScope(rect))
            {
                DrawInternal();
            }
        }

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            DefaultStyle = GUIStyle.none.Duplicate();
        }
    }
}