using Escolar.Commands;
using Escolar.Context;
using Microsoft.EntityFrameworkCore;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;

namespace Escolar.ViewModels
{
  public class AlunoListViewModel : ListViewModelBase
  {

    private readonly AlunoContext Context;
    //private CollectionViewSource turmaAlunoViewSource;

    private ObservableCollection<Models.Serie> _seriesOC;
    private ObservableCollection<Models.Turma> _turmasOC;

    public override ICommand SearchCommand { get; }

    public ObservableCollection<Models.Serie> SeriesOC
    {
      get { return _seriesOC; }
      set
      {
        _seriesOC = value;
        OnPropertyChanged(nameof(SeriesOC));
      }
    }

    public ObservableCollection<Models.Turma> TurmasOC
    {
      get { return _turmasOC; }
      set
      {
        _turmasOC = value;
        OnPropertyChanged(nameof(TurmasOC));
      }
    }

    public ListCollectionView serieViewSource;

    public AlunoListViewModel()
    {
      SearchCommand = new ListSearchCommand(this);

      Context = new AlunoContext();
      // this is for demo purposes only, to make it easier
      // to get up and running
      //Context.Database.EnsureDeleted();
      Context.Database.EnsureCreated();

      // load the entities into EF Core
      Context.Series.Load();


      this.SeriesOC = Context.Series.Local.ToObservableCollection();
    }

    public void SeriesComboBox_SelectionChanged()
    {
      Console.WriteLine("consolezao da mascada!!");

      Context.Turmas.Load();
      this.TurmasOC = Context.Turmas.Local.ToObservableCollection();
    }

    public void Unload()
    {
      // clean up database connections
      Context.Dispose();
    }

    public override void Search()
    {
    }
  }
}
