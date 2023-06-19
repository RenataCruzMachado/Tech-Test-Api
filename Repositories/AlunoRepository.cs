using tech_test_api.Models;
using tech_test_api.Context;
using Microsoft.EntityFrameworkCore;


namespace tech_test_api.Repositories{
    public class AlunoRepository: IAlunoRepository{

        private readonly CourseDbContext _context;

        public AlunoRepository(CourseDbContext context){
            _context = context;
        }

        public void Add(Aluno aluno){
            try{
                _context.Alunos.Add(aluno);
                _context.SaveChanges();
            }catch(Exception e){
                throw(new Exception(e.InnerException.ToString()));
            }
        }

        public List<Aluno> GetAll(){
            return _context.Alunos
            .Include(a => a.Matriculas)
            .AsNoTracking()
            .ToList();
        }

        public Aluno GetById(int id){
            return  _context.Alunos
            .Include(a => a.Matriculas)
            .FirstOrDefault(a => a.Id == id);
        }

        public void Update(Aluno aluno){
            _context.Alunos.Update(aluno);
            _context.SaveChanges();
        }

        public void Delete(Aluno aluno){
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
        }

    }
}