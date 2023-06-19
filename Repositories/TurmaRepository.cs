using tech_test_api.Models;
using tech_test_api.Context;
using Microsoft.EntityFrameworkCore;


namespace tech_test_api.Repositories{
    public class TurmaRepository: ITurmaRepository{
         private readonly CourseDbContext _context;

        public TurmaRepository(CourseDbContext context){
            _context = context;
        }


        public void Add(Turma turma){
            var anoAtual = DateTime.Now.Year;
            turma.AnoLetivo = anoAtual;
            _context.Turmas.Add(turma);
            _context.SaveChanges();
        }

        public List<Turma> GetAll(){
            return _context.Turmas
            .Include(a => a.Matriculas)
            .AsNoTracking()
            .ToList();
        }

        public Turma GetById(int id){
             return  _context.Turmas
            .Include(a => a.Matriculas)
            .FirstOrDefault(a => a.Id == id);
        }

        public void Update(Turma turma){
            _context.Turmas.Update(turma);
            _context.SaveChanges();
        }

        public void Delete(Turma turma){
            _context.Turmas.Remove(turma);
            _context.SaveChanges();
        }
    }
}