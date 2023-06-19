using tech_test_api.Models;

namespace tech_test_api.Repositories
{
    public interface IMatriculaRepository
    {
        void Add(Matricula entity);
        List<Matricula> GetAll();
        void Delete(Matricula entity);
    }
}