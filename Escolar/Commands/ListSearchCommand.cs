using Escolar.ViewModels;
using MVVMEssentials.ViewModels;
using Escolar.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Escolar.Commands
{
  public class ListSearchCommand : BaseCommand
  {

    private readonly ListViewModelBase _listViewModel;

    public ListSearchCommand(ListViewModelBase listViewModel)
    {
      _listViewModel = listViewModel;
      _listViewModel.PropertyChanged += ViewModel_PropertyChanged;
    }

    public override bool CanExecute(object parameter)
    {
      return true;
      //return _viewModel.IsValidList;
    }

    public override void Execute(object parameter)
    {
      _listViewModel.Search();
    }

    private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      //if (e.PropertyName == nameof(ViewModel.IsValidList))
      //{
      //  OnCanExecuteChanged();
      //}
    }
  }
}
