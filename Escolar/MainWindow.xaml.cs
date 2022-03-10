using Escolar.ViewModels;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace Escolar
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public ICommand NavigateAlunoListCommand { get; }
    public ICommand NavigateProfessorCommand { get; }
    public ICommand NavigateTurmaCommand { get; }

    private readonly NavigationStore _navigationStore;


    public MainWindow(NavigationStore navigationStore)
    {
      InitializeComponent();
      _navigationStore = navigationStore;
      NavigateAlunoListCommand = new NavigateCommand(CreateAlunoListNavigationService());
      NavigateProfessorCommand = new NavigateCommand(CreateProfessorNavigationService());
      NavigateTurmaCommand = new NavigateCommand(CreateTurmaNavigationService());
    }

    private void AlunoListButton_Click(object sender, RoutedEventArgs e)
    {
      INavigationService navigationService = CreateAlunoListNavigationService();
      navigationService.Navigate();
    }

    private void ProfessorButton_Click(object sender, RoutedEventArgs e)
    {
      INavigationService navigationService = CreateProfessorNavigationService();
      navigationService.Navigate();
    }

    private void TurmaButton_Click(object sender, RoutedEventArgs e)
    {
      INavigationService navigationService = CreateTurmaNavigationService();
      navigationService.Navigate();
    }

    private INavigationService CreateMainMenuNavigationService()
    {
      return new NavigationService<MainMenuViewModel>(_navigationStore, CreateMainMenuViewModel);
    }

    private MainMenuViewModel CreateMainMenuViewModel()
    {
      return new MainMenuViewModel(_navigationStore);
    }

    private INavigationService CreateAlunoListNavigationService()
    {
      return new NavigationService<AlunoListViewModel>(_navigationStore, CreateAlunoListViewModel);
    }

    private AlunoListViewModel CreateAlunoListViewModel()
    {
      return new AlunoListViewModel();
    }

    private INavigationService CreateProfessorNavigationService()
    {
      return new NavigationService<ProfessorViewModel>(_navigationStore, CreateProfessorViewModel);
    }

    private ProfessorViewModel CreateProfessorViewModel()
    {
      return new ProfessorViewModel(CreateMainMenuNavigationService());
    }
    private INavigationService CreateTurmaNavigationService()
    {
      return new NavigationService<TurmaViewModel>(_navigationStore, CreateTurmaViewModel);
    }

    private TurmaViewModel CreateTurmaViewModel()
    {
      return new TurmaViewModel(CreateMainMenuNavigationService());
    }
  }
}
