using Escolar;
using Escolar.ViewModels;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;
using System.Windows;

namespace Escolar
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private readonly NavigationStore _navigationStore;
    private readonly ModalNavigationStore _modalNavigationStore;

    public App()
    {
      _navigationStore = new NavigationStore();
      _modalNavigationStore = new ModalNavigationStore();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
      INavigationService navigationService = CreateMainMenuNavigationService();
      navigationService.Navigate();

      MainWindow = new MainWindow(_navigationStore)
      {
        DataContext = new MainViewModel(_navigationStore, _modalNavigationStore)
      };
      MainWindow.Show();

      base.OnStartup(e);
    }

    private INavigationService CreateMainMenuNavigationService()
    {
      return new NavigationService<MainMenuViewModel>(_navigationStore, CreateMainMenuViewModel);
    }

    private MainMenuViewModel CreateMainMenuViewModel()
    {
      return new MainMenuViewModel(_navigationStore);

    }
  }
}
