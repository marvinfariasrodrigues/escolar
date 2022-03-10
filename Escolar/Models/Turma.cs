using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Escolar.Models
{
  public class Turma
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public int SerieId { get; set; }
    public virtual ICollection<Aluno> Alunos
    { get; private set; } = new ObservableCollection<Aluno>();
  }
}
