using System;
using System.Collections.Generic;
using UnityEngine;

namespace BeardPhantom.RETGUI
{
    /// <summary>
    /// A callback to execute once on the next draw call. Useful for using API's like GUI.skin that can
    /// only be accessed during
    /// </summary>
    /// <param name="element"></param>
    public delegate void DrawCallback(Element element);

    /// <summary>
    /// The most basic unit of UI.
    /// </summary>
    public abstract class Element
    {
        /// <summary>
        /// Globally enables/disables all element drawing
        /// </summary>
        public static bool DrawingEnabled = true;

        /// <summary>
        /// </summary>
        private readonly Queue<DrawCallback> _onDrawCallbacks = new Queue<DrawCallback>();

        /// <summary>
        /// Id for querying elements
        /// </summary>
        public string Id = Guid.NewGuid().ToString();

        /// <summary>
        /// Style to use for rendering
        /// </summary>
        public GUIStyle ActiveStyle;

        /// <summary>
        /// Colors used for rendering this element
        /// </summary>
        public ColorSet Colors = new ColorSet();

        /// <summary>
        /// Whether GUI is enabled for this element
        /// </summary>
        public bool Enabled = true;

        /// <summary>
        /// The default style for this element
        /// </summary>
        public GUIStyle DefaultStyle { get; protected set; }

        /// <summary>
        /// Create element with no initializer function
        /// </summary>
        protected Element()
        {
            AddInitializerFunction();
        }

        /// <summary>
        /// Create element with initializer function
        /// </summary>
        protected Element(DrawCallback initializer)
        {
            AddInitializerFunction();
            AddCallbackForNextDraw(initializer);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return GetElementDebugString();
        }

        /// <summary>
        /// Resets style to be the same as the default element style
        /// </summary>
        public void RestoreDefaultStyle()
        {
            ActiveStyle = DefaultStyle.Duplicate();
        }

        /// <summary>
        /// Adds a callback that will be executed once during next draw call
        /// </summary>
        public void AddCallbackForNextDraw(DrawCallback onDraw)
        {
            _onDrawCallbacks.Enqueue(onDraw);
        }

        /// <summary>
        /// Returns a debug info string
        /// </summary>
        public string GetElementDebugString()
        {
            return $"{GetType().Name} | ID:{Id} | Enabled:{Enabled}";
        }

        /// <summary>
        /// Draw using autolayout
        /// </summary>
        public void Draw()
        {
            ExecDraw(null);
        }

        /// <summary>
        /// Draw using rect
        /// </summary>
        public void Draw(Rect rect)
        {
            ExecDraw(rect);
        }

        /// <summary>
        /// Internal draw function using autolayout
        /// </summary>
        protected abstract void DrawInternal();

        /// <summary>
        /// Internal draw function using a rect
        /// </summary>
        protected abstract void DrawInternal(Rect rect);

        /// <summary>
        /// Called on very first draw call
        /// </summary>
        protected abstract void OnInitialize();

        /// <summary>
        /// Adds initializer callback function
        /// </summary>
        private void AddInitializerFunction()
        {
            AddCallbackForNextDraw(element =>
            {
                OnInitialize();
                if(DefaultStyle == null)
                {
                    throw new Exception("OnInitialize did not provide DefaultStyle");
                }
                RestoreDefaultStyle();
            });
        }

        /// <summary>
        /// Executes draw function based on existing rect
        /// </summary>
        private void ExecDraw(Rect? rect)
        {
            while(_onDrawCallbacks.Count > 0)
            {
                var callback = _onDrawCallbacks.Dequeue();
                callback?.Invoke(this);
            }

            if(!DrawingEnabled)
            {
                return;
            }

            // Store GUI state
            var cachedEnabled = GUI.enabled;
            var cachedColor = GUI.color;
            var cachedBackgroundColor = GUI.backgroundColor;
            var cachedContentColor = GUI.contentColor;
            GUI.enabled = cachedEnabled && Enabled;
            GUI.color = Colors.Color;
            GUI.backgroundColor = Colors.BackgroundColor;
            GUI.contentColor = Colors.ContentColor;

            if (rect.HasValue)
            {
                DrawInternal(rect.Value);
            }
            else
            {
                DrawInternal();
            }

            // Restore GUI state
            GUI.contentColor = cachedContentColor;
            GUI.backgroundColor = cachedBackgroundColor;
            GUI.color = cachedColor;
            GUI.enabled = cachedEnabled;
        }
    }
}