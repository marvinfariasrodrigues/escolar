using Escolar.Interface;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Escolar.ViewModels
{
  public class ListViewModelBase : ViewModelBase, IListViewModelBase
  {
    public virtual ICommand SearchCommand { get; }
    public virtual ICommand EditRegisterCommand { get; }

    public virtual void EditRegister()
    {
      throw new NotImplementedException();
    }

    public virtual void Search()
    {
      throw new NotImplementedException();
    }
  }
}
