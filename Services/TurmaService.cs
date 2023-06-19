using tech_test_api.Repositories;
using tech_test_api.Models;
using tech_test_api.Dtos;

namespace tech_test_api.Services
{
    public class TurmaService: ITurmaService{
        private readonly ITurmaRepository _turmaRepository;

        public TurmaService(ITurmaRepository turmaRepository){
            _turmaRepository = turmaRepository;
        }

        public List<Turma> GetTurmas(){
            return _turmaRepository.GetAll();
        }

        public Turma GetTurmaById(int id){
            var aluno = _turmaRepository.GetById(id);
            if (aluno != null){
                return _turmaRepository.GetById(id);
            }
                throw new Exception("Turma não encontrada");
        }

        public void AddTurma(TurmaDto turma){

            if (_turmaRepository.GetAll().Any(item => item.NomeTurma == turma.NomeTurma)){
                throw new Exception("Já existe uma turma com o mesmo nome.");
            }

            var turmaDto = new Turma{
                NomeTurma = turma.NomeTurma,
                AnoLetivo = turma.AnoLetivo,
                QtdMaximaAlunos = turma.QtdMaximaAlunos
            };
            
            _turmaRepository.Add(turmaDto);
        }
        public void UpdateTurma(Turma turma){
            _turmaRepository.Update(turma);
        }

        public void DeleteTurma(int id){
            var turma = _turmaRepository.GetById(id);
            if (turma != null){
                _turmaRepository.Delete(turma);
            }
            else{
                throw new Exception("Turma não encontrada");
            }
            // Validação caso uma turma tenha alunos, não poderá ser excluída.
            if (turma.Matriculas.Any()){
                throw new Exception("A turma possui alunos e não pode ser excluída.");
            }

            _turmaRepository.Delete(turma);
        }
    }
}