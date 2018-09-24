namespace BeardPhantom.RETGUI
{
    /// <summary>
    /// An editor content pattern that encourages tree structured event driven GUI
    /// </summary>
    public abstract class REGUIEditorContent
    {
        /// <summary>
        /// The root element that is drawn
        /// </summary>
        public IElement RootElement { get; private set; }

        /// <summary>
        /// Rebuilds UI
        /// </summary>
        protected REGUIEditorContent()
        {
            RebuildUI();
        }

        /// <summary>
        /// Rebuilds UI from scratch
        /// </summary>
        public void RebuildUI()
        {
            RootElement = BuildRootElement();
        }

        /// <summary>
        /// Draws this content
        /// </summary>
        public void Draw()
        {
            RootElement.Draw();
        }

        /// <summary>
        /// Function responsible for building entire GUI, returning the root element.
        /// </summary>
        protected abstract IElement BuildRootElement();
    }
}