using System;
using System.Windows;
using System.Windows.Input;

namespace InveTime.WPF.Infrastructure.Commands
{
    /// <summary>Command, what closing all Application</summary>
    class CloseAppCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => Application.Current.Shutdown();
    }
}
