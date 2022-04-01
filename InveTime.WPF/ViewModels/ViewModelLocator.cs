using InveTime.WPF.ViewModels.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace InveTime.WPF.ViewModels
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
