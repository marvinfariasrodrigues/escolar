using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Escolar.ViewModels
{

  public class TurmaViewModel : ViewModelBase
  {
    public ICommand NavigateMainMenuCommand { get; }

    public TurmaViewModel(INavigationService mainMenuNavigationService)
    {
      NavigateMainMenuCommand = new NavigateCommand(mainMenuNavigationService);
    }
  }
}
