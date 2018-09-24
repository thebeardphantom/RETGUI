using System.Collections.Generic;
using BeardPhantom.RETGUI.Widgets;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace BeardPhantom.RETGUI.List
{
    /// <summary>
    /// A list of widgets
    /// </summary>
    public class WidgetList : Element<WidgetList>
    {
        /// <summary>
        /// The underlying data model
        /// </summary>
        private WidgetListModel _model;

        /// <summary>
        /// View that renders the model
        /// </summary>
        private WidgetListView _view;

        /// <summary>
        /// Should fixed row height be used
        /// </summary>
        public bool UseFixedRowHeight
        {
            get => _view.UseFixedRowHeight;
            set => _view.UseFixedRowHeight = value;
        }

        /// <summary>
        /// Access to view row height
        /// </summary>
        public float RowHeight
        {
            get => _view.RowHeight;
            set => _view.RowHeight = value;
        }

        /// <summary>
        /// Access to view scroll position
        /// </summary>
        public Vector2 ScrollPosition
        {
            get => _view.ScrollPosition;
            set => _view.ScrollPosition = value;
        }

        /// <inheritdoc />
        public WidgetList()
        {
            CreateModelView();
        }

        /// <inheritdoc />
        public WidgetList(DrawCallback<WidgetList> initializer) : base(initializer)
        {
            CreateModelView();
        }

        /// <summary>
        /// Sets data on model
        /// </summary>
        public void SetData(IList<IWidget> widgets)
        {
            _model.SetData(widgets);
            ReloadView();
        }

        /// <inheritdoc />
        protected override void DrawInternal()
        {
            using(var scope = new EditorGUILayout.VerticalScope(GUILayout.ExpandHeight(true)))
            {
                CheckRefreshRowHeights();
                _view.OnGUI(scope.rect);
            }
        }

        /// <inheritdoc />
        protected override void DrawInternal(Rect rect)
        {
            CheckRefreshRowHeights();
            _view.OnGUI(rect);
        }

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            DefaultStyle = GUIStyle.none.Duplicate();
        }

        /// <summary>
        /// Reloads the view from the model
        /// </summary>
        private void ReloadView()
        {
            _view.Reload();
            CheckRefreshRowHeights();
        }

        /// <summary>
        /// Updates custom row heights if used
        /// </summary>
        private void CheckRefreshRowHeights()
        {
            if(!_view.UseFixedRowHeight
                && Mathf.Approximately(_view.totalHeight, 0f)
                && Event.current.type == EventType.Repaint)
            {
                _view.RefreshRowHeights();
            }
        }

        /// <summary>
        /// Creates model and view
        /// </summary>
        private void CreateModelView()
        {
            _model = new WidgetListModel();
            _view = new WidgetListView(new TreeViewState(), _model);
        }
    }
}