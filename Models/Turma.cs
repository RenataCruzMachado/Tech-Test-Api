namespace tech_test_api.Models
{
    public class Turma{
       
      public Turma(){
        Matriculas = new List<Matricula>();
      }

      public int Id { get; set; }
      public string NomeTurma { get; set; }
      public int AnoLetivo { get; set; }
      public int QtdMaximaAlunos { get; set; }
      public virtual List<Matricula> Matriculas { get; set; }
        
    }
}