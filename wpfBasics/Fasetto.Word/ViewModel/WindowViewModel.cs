using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// the view model for the custom flat window
    /// </summary>
    class WindowViewModel :BaseViewModel
    {
        #region Private member
        private Window mWindow;

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 10;
        #endregion

        #region Public Properties

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;
        
        /// <summary>
        /// The Size of the resize border around the windows, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder+OuterMarginSize); } }
        
        public int OuterMarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>   
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The Height of the title bar/ caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight+ResizeBorder); } }
        #endregion


        #region Constructor
        public WindowViewModel(Window window)
        {
            mWindow = window;

            // Listen out for the window resizing
            mWindow.StateChanged += (sender, e) =>
             {
                 // Fire off events for all properties that are affected by resize
                 OnPropertyChanged(nameof(ResizeBorderThickness));
                 OnPropertyChanged(nameof(OuterMarginSize));
                 OnPropertyChanged(nameof(OuterMarginSizeThickness));
                 OnPropertyChanged(nameof(WindowRadius));
                 OnPropertyChanged(nameof(WindowCornerRadius));
             };
        }
        #endregion


    }
}
