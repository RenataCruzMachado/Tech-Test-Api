using tech_test_api.Models;


namespace tech_test_api.Repositories
{
    public interface IAlunoRepository{
        void Add(Aluno entity);
        List<Aluno>GetAll();
        Aluno GetById(int id);
        void Update(Aluno entity);
        void Delete(Aluno entity);
    }
}