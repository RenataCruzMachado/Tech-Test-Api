using System.Collections.Generic;
using tech_test_api.Models;
using tech_test_api.Dtos;

namespace tech_test_api.Services
{
    public interface ITurmaService
    {
        void AddTurma(TurmaDto turma);
        List<Turma> GetTurmas();
        Turma GetTurmaById(int id);
        void UpdateTurma(Turma turma);
        void DeleteTurma(int id);
    }
}