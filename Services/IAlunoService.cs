using System.Collections.Generic;
using tech_test_api.Models;
using tech_test_api.Dtos;

namespace tech_test_api.Services
{
    public interface IAlunoService
    {
        void AddAluno(AlunoDto aluno);
        List<Aluno>GetAllAlunos();
        Aluno GetAlunoById(int id);
        void UpdateAluno(Aluno aluno);
        void DeleteAluno(int id);
    }
}