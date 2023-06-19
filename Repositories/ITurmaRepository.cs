using tech_test_api.Models;

namespace tech_test_api.Repositories
{
    public interface ITurmaRepository{
        void Add(Turma entity);
        List<Turma> GetAll();
        Turma GetById(int id);
        void Update(Turma entity);
        void Delete(Turma entity);
    }
}