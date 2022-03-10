using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Escolar.Models
{
  public class Serie
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public virtual ICollection<Turma> Turmas
    { get; private set; } = new ObservableCollection<Turma>();
  }
}
