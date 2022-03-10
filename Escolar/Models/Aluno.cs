
using System;

namespace Escolar.Models
{
  public class Aluno
  {
    private int _id;

    public int Id
    {
      get { return _id; }
      set { _id = value; }
    }

    private string _nome;

    public string Nome
    {
      get { return _nome; }
      set { _nome = value; }
    }


    //public int Id { get; set; }
    //public string Nome { get; set; }
    //public string Sobrenome { get; set; }
    //public int TurmaId { get; set; }
  }
}
