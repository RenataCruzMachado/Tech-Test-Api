namespace tech_test_api.Models
{
    public class Aluno
    {
        public Aluno(){
            Matriculas = new List<Matricula>();
        }

        public int Id { get; set; }
        public string NomeAluno { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public virtual List<Matricula> Matriculas { get; set; }
    }
}