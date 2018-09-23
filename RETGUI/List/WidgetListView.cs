using System.Linq;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace BeardPhantom.RETGUI.List
{
    /// <summary>
    /// Rendered view of list model
    /// </summary>
    internal class WidgetListView : TreeView
    {
        /// <summary>
        /// Reference to model for rendering
        /// </summary>
        private readonly WidgetListModel _model;

        /// <summary>
        /// Should custom or fixed row height be used
        /// </summary>
        public bool UseFixedRowHeight { get; set; }

        /// <summary>
        /// Access to fixed row height
        /// </summary>
        public float RowHeight
        {
            get => rowHeight;
            set => rowHeight = value;
        }

        /// <summary>
        /// Access to scroll position
        /// </summary>
        public Vector2 ScrollPosition
        {
            get => state.scrollPos;
            set => state.scrollPos = value;
        }

        /// <inheritdoc />
        public WidgetListView(TreeViewState state, WidgetListModel model) : base(state)
        {
            _model = model;
        }

        /// <summary>
        /// Recalculates row heights
        /// </summary>
        public void RefreshRowHeights()
        {
            RefreshCustomRowHeights();
        }

        /// <inheritdoc />
        protected override bool CanMultiSelect(TreeViewItem item)
        {
            return false;
        }

        /// <inheritdoc />
        protected override TreeViewItem BuildRoot()
        {
            var root = new TreeViewItem(-1, -1, "Root");
            var children = _model.Data == null
                ? new TreeViewItem[0]
                : _model.Data.Select((element, index) => new TreeViewItem(index, 0, element.Id)).ToArray();
            SetupParentsAndChildrenFromDepths(root, children);
            return root;
        }

        /// <inheritdoc />
        protected override float GetCustomRowHeight(int row, TreeViewItem item)
        {
            if(UseFixedRowHeight)
            {
                return rowHeight;
            }
            var widget = _model.Data[row];
            return widget.CalcHeight();
        }

        /// <inheritdoc />
        protected override void RowGUI(RowGUIArgs args)
        {
            var widget = _model.Data[args.row];
            widget.Draw(args.rowRect);
        }
    }
}