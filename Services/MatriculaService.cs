using tech_test_api.Repositories;
using tech_test_api.Models;
using tech_test_api.Dtos;

namespace tech_test_api.Services{
    public class MatriculaService:IMatriculaService{
        private readonly IAlunoRepository _alunoRepository;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMatriculaRepository _matriculaRepository;


        public MatriculaService(IAlunoRepository alunoRepository, ITurmaRepository turmaRepository, IMatriculaRepository matriculaRepository){
            _alunoRepository = alunoRepository;
            _turmaRepository = turmaRepository;
            _matriculaRepository = matriculaRepository;
        }

        public void AddMatricula(MatriculaDto matricula){
            
            // Verificar se a matrícula já existe na mesma turma
            if (_matriculaRepository.GetAll().Any(m => m.TurmaId == matricula.TurmaId && m.AlunoId == matricula.AlunoId))
            {
                throw new Exception("A matrícula já existe para o aluno na turma especificada.");
            }
            // Validação caso exceda a quantidade máxima de alunos na turma.
            var qtdalunos = _turmaRepository.GetById(matricula.TurmaId);
            if (qtdalunos.Matriculas.Count >= qtdalunos.QtdMaximaAlunos){
                throw new Exception($"A turma já atingiu a quantidade máxima de alunos.");
            }
            // Verifica se o aluno e turma existem. Se sim, é criado nova instância recebendo os Ids.
            var aluno = _alunoRepository.GetById(matricula.AlunoId);
            var turma = _turmaRepository.GetById(matricula.TurmaId);

            if (aluno == null || turma == null){
                throw new Exception("Dados não encontrados.");
            }

            var mat = new Matricula{
                TurmaId = turma.Id,
                AlunoId= aluno.Id
            };

            _matriculaRepository.Add(mat);
        }

        public List<Matricula> GetAllMatriculas(){
            return _matriculaRepository.GetAll();
        }
       
        public void DeleteMatricula(int alunoId){

            var matricula =  _matriculaRepository.GetAll().Find(m => m.AlunoId == alunoId);
            
            if (matricula == null ){
                throw new Exception("Matrícula não encontrada.");
            }

            _matriculaRepository.Delete(matricula);
        }
    }
}