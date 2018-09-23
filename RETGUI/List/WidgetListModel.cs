using System.Collections.Generic;
using System.Linq;
using BeardPhantom.RETGUI.Widgets;

namespace BeardPhantom.RETGUI.List
{
    /// <summary>
    /// Underlying data model for lists
    /// </summary>
    internal class WidgetListModel
    {
        /// <summary>
        /// </summary>
        public Widget[] Data;

        /// <summary>
        /// </summary>
        private IList<Widget> _data;

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        public void SetData(IList<Widget> data)
        {
            _data = data;
            Data = data.ToArray();
        }
    }
}