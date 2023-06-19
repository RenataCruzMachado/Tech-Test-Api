using tech_test_api.Repositories;
using tech_test_api.Models;
using tech_test_api.Dtos;


namespace tech_test_api.Services{
    public class AlunoService: IAlunoService{
       

        private readonly IAlunoRepository _alunoRepository;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMatriculaRepository _matriculaRepository;

        public AlunoService(IAlunoRepository alunoRepository, ITurmaRepository turmaRepository, IMatriculaRepository matriculaRepository)
        {
            _alunoRepository = alunoRepository;
            _turmaRepository = turmaRepository;
            _matriculaRepository = matriculaRepository;
        }

         public void AddAluno(AlunoDto aluno){
            
            if (_alunoRepository.GetAll().Any(item => item.CPF == aluno.CPF)){
                throw new Exception("Já existe um aluno cadastrado com o CPF informado.");
            }

            var alunoDto = new Aluno{
                NomeAluno = aluno.NomeAluno,
                CPF = aluno.CPF,
                Email = aluno.Email,
                Telefone = aluno.Telefone
            };

            _alunoRepository.Add(alunoDto);
        }

        public Aluno GetAlunoById(int id){
            var aluno = _alunoRepository.GetById(id);
            if (aluno != null){
                return _alunoRepository.GetById(id);
            }
                throw new Exception("Aluno não encontrado");
        }

        public List<Aluno> GetAllAlunos(){
            return _alunoRepository.GetAll();
        }

        public void UpdateAluno(Aluno aluno){
            
            _alunoRepository.Update(aluno);
        }

        public void DeleteAluno(int id){
            var aluno = _alunoRepository.GetById(id);
            if (aluno != null){
                _alunoRepository.Delete(aluno);
            }
            else{
                throw new Exception("Aluno não encontrado");
            }
        }
    }
}   