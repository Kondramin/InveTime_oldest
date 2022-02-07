using InveTime.WPF.ViewModels.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace InveTime.WPF.ViewModels
{
    public static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            ;
    }
}
