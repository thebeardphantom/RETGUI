﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BeardPhantom.RETGUI.Groups
{
    /// <summary>
    /// A group of elements in a layout
    /// </summary>
    public abstract class ElementGroup<T> : Element<T> where T : Element<T>
    {
        /// <summary>
        /// All elements under this group
        /// </summary>
        public readonly List<IElement> Elements = new List<IElement>();

        /// <inheritdoc />
        protected ElementGroup() { }

        /// <inheritdoc />
        protected ElementGroup(DrawCallback<T> initializer) : base(initializer) { }

        /// <summary>
        /// A group with elements to start
        /// </summary>
        protected ElementGroup(params IElement[] elements)
        {
            Elements.AddRange(elements);
        }

        /// <summary>
        /// A group with elements to start
        /// </summary>
        protected ElementGroup(DrawCallback<T> initializer, params IElement[] elements) : base(initializer)
        {
            Elements.AddRange(elements);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder();
            var depth = new Stack<int>();
            var items = new Stack<IElement>();
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
                if(current is ElementGroup<T> group)
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
        public E FindElementById<E>(string id) where E : Element<T>
        {
            return (E) Elements.SingleOrDefault(element => element.Id == id);
        }

        /// <summary>
        /// Adds elements to group
        /// </summary>
        public void AddElements(params IElement[] elements)
        {
            Elements.AddRange(elements);
        }

        /// <summary>
        /// Removes elements from group
        /// </summary>
        public void RemoveElements(params IElement[] elements)
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