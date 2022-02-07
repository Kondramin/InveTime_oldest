using InveTime.WPF.ViewModels.ViewsViewModels;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System.Windows.Input;

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



        #region ViewModel MainWindow CurrentModel

        private ViewModel _CurrentModel;
        /// <summary>MainWindow CurrentModel</summary>
        public ViewModel CurrentModel
        {
            get => _CurrentModel;
            set => Set(ref _CurrentModel, value);
        }

        #endregion



        #region Commands


        #region Command ShowStartViewCommand - Show StartView

        /// <summary>Show StartView</summary>
        private ICommand _ShowStartViewCommand;

        /// <summary>Show StartView</summary>
        public ICommand ShowStartViewCommand => _ShowStartViewCommand
            ??= new LambdaCommand(OnShowStartViewCommandExequted, CanShowStartViewCommandExequt);

        /// <summary>Checking the possibility of execution - Show StartView</summary>
        public bool CanShowStartViewCommandExequt(object p) => true;

        /// <summary>Execution logic - Show StartView</summary>
        public void OnShowStartViewCommandExequted(object p)
        {
            CurrentModel = new StartViewModel();
        }

        #endregion


        #endregion

    }
}
