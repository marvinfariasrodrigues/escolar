using Escolar.Context;
using Microsoft.EntityFrameworkCore;
using MVVMEssentials.Commands;
using MVVMEssentials.Services;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Escolar.ViewModels
{
  public class AlunoViewModel : ViewModelBase
  {
    public ICommand NavigateMainMenuCommand { get; }

    private readonly AlunoContext Context;

    public ObservableCollection<Models.Serie> SeriesOC;

    public AlunoViewModel(INavigationService mainMenuNavigationService)
    {
      NavigateMainMenuCommand = new NavigateCommand(mainMenuNavigationService);

      Context = new AlunoContext();
      // this is for demo purposes only, to make it easier
      // to get up and running
      //Context.Database.EnsureDeleted();
      Context.Database.EnsureCreated();

      // load the entities into EF Core
      Context.Series.Load();

      this.SeriesOC = Context.Series.Local.ToObservableCollection();
    }

    public void Unload()
    {
      // clean up database connections
      Context.Dispose();
    }

    public void Save()
    {
      Console.Write("gravou!");
    }
  }
}