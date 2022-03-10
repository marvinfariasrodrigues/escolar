using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Escolar.ViewModels
{
  public class AccountViewModel : ViewModelBase
  {
    public ICommand NavigateHomeCommand { get; }

    public AccountViewModel(INavigationService homeNavigationService)
    {
      NavigateHomeCommand = new NavigateCommand(homeNavigationService);
    }
  }
}
