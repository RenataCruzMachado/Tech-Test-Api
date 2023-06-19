using tech_test_api.Context;
using tech_test_api.Models;

namespace tech_test_api.Repositories
{
    public class MatriculaRepository:IMatriculaRepository
    {
         private readonly CourseDbContext _context;

        public MatriculaRepository(CourseDbContext context){
            _context = context;
        }

        public void Add(Matricula matricula){
           try{
                _context.Matriculas.Add(matricula);
                _context.SaveChanges();
            }catch(Exception e){
                throw(new Exception(e.InnerException.ToString()));
            }
        }

        public List<Matricula>GetAll(){
            return _context.Matriculas.ToList();
        }

        public void Delete(Matricula matricula){
            _context.Matriculas.Remove(matricula);
            _context.SaveChanges();
        }
    }
}