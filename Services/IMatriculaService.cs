using tech_test_api.Models;
using tech_test_api.Dtos;

namespace tech_test_api.Services
{
    public interface IMatriculaService
    {
        void AddMatricula(MatriculaDto matricula);
        List<Matricula> GetAllMatriculas();
        void DeleteMatricula(int id); 
    }
}