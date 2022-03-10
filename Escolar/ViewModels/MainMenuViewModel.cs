using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;
using System.Windows.Input;

namespace Escolar.ViewModels
{
  public class MainMenuViewModel : ViewModelBase
  {
    public ICommand NavigateAlunoCommand { get; }
    public ICommand NavigateProfessorCommand { get; }
    public ICommand NavigateTurmaCommand { get; }

    private readonly NavigationStore _navigationStore;

    public MainMenuViewModel(NavigationStore navigationStore)
    {
      _navigationStore = navigationStore;
      NavigateAlunoCommand = new NavigateCommand(CreateAlunoListNavigationService());
      NavigateProfessorCommand = new NavigateCommand(CreateProfessorNavigationService());
      NavigateTurmaCommand = new NavigateCommand(CreateTurmaNavigationService());
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