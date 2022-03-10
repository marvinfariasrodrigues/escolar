using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Escolar.ViewModels
{

  public class ProfessorViewModel : ViewModelBase
  {
    public ICommand NavigateMainMenuCommand { get; }

    public ProfessorViewModel(INavigationService mainMenuNavigationService)
    {
      NavigateMainMenuCommand = new NavigateCommand(mainMenuNavigationService);
    }
  }
}
