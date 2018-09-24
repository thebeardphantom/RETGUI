using UnityEngine;

namespace BeardPhantom.RETGUI
{
    /// <summary>
    /// Basic element implementation
    /// </summary>
    public interface IElement
    {
        /// <summary>
        /// Draw using autolayout
        /// </summary>
        void Draw();

        /// <summary>
        /// Draw using rect
        /// </summary>
        void Draw(Rect rect);

        /// <summary>
        /// Id for querying elements
        /// </summary>
        string Id { get; set; }
    }
}