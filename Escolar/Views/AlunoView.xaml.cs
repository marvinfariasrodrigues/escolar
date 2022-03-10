using Escolar.Context;
using Escolar.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Escolar.Views
{
  /// <summary>
  /// Interaction logic for AlunosView.xaml
  /// </summary>
  public partial class AlunoView : UserControl
  {
    private CollectionViewSource serieViewSource;
    private CollectionViewSource serieTurmaViewSource;
    private CollectionViewSource turmaAlunoViewSource;

    //private AlunoViewModel viewModel = new AlunoViewModel();

    public AlunoView()
    {
      InitializeComponent();

      //serieViewSource =
      //          (CollectionViewSource)FindResource(nameof(serieViewSource));
      //serieTurmaViewSource =
      //          (CollectionViewSource)FindResource(nameof(serieTurmaViewSource));
      //turmaAlunoViewSource =
      //          (CollectionViewSource)FindResource(nameof(turmaAlunoViewSource));

      //serieViewSource.Source = viewModel.SeriesOC;
    }

    private void AlunoUserControl_Loaded(object sender, RoutedEventArgs e)
    {

    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
      //viewModel.Save();
      ////PrintDialog printDlg = new PrintDialog();
      ////printDlg.PrintVisual(this, "User Control Printing.");
      //// this forces the grid to refresh to latest values
      //serieDataGrid.Items.Refresh();
      //serieTurmasDataGrid.Items.Refresh();
      //turmaAlunosDataGrid.Items.Refresh();
    }

    private void AlunoUserControl_Unloaded(object sender, RoutedEventArgs e)
    {
      
    }
  }
}
