using MathCore.WPF.ViewModels;

namespace InveTime.WPF.ViewModels.Windows
{
    public class MainWindowViewModel : ViewModel
    {
        #region MainWindow string Title  = "InveTime"

        private string _Title = "InveTime";
        /// <summary>MainWindow title</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion
    }
}
