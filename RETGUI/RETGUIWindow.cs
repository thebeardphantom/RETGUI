using UnityEditor;

namespace BeardPhantom.RETGUI
{
    /// <summary>
    /// An editor window pattern that encourages tree structured event driven GUI
    /// </summary>
    public abstract class RETGUIWindow : EditorWindow
    {
        /// <summary>
        /// The root element that is drawn
        /// </summary>
        public IElement RootElement { get; private set; }

        /// <summary>
        /// Rebuilds UI from scratch
        /// </summary>
        public void RebuildUI()
        {
            RootElement = BuildRootElement();
        }

        /// <summary>
        /// Function responsible for building entire GUI, returning the root element.
        /// </summary>
        protected abstract IElement BuildRootElement();

        /// <summary>
        /// Rebuilds UI on enable
        /// </summary>
        protected virtual void OnEnable()
        {
            RebuildUI();
        }

        /// <summary>
        /// Unity GUI call
        /// </summary>
        private void OnGUI()
        {
            RootElement.Draw();
        }
    }
}