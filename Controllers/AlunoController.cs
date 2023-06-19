using Microsoft.AspNetCore.Mvc;
using tech_test_api.Models;
using tech_test_api.Services;
using tech_test_api.Dtos;


namespace tech_test_api.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class AlunoController:ControllerBase{
        private readonly IAlunoService _alunoService;
      

        public AlunoController(IAlunoService alunoService){
            _alunoService = alunoService;
        }

        
        [HttpPost]
         public ActionResult<AlunoDto> AddAluno([FromBody] AlunoDto aluno){  
            try{
                _alunoService.AddAluno(aluno);
                return CreatedAtAction(nameof(GetAlunoById), new { id = aluno.Id }, aluno);
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Aluno>> GetAllAlunos(){
            var alunos = _alunoService.GetAllAlunos();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public ActionResult<Aluno> GetAlunoById(int id){
            var aluno = _alunoService.GetAlunoById(id);
            try{
                return Ok(aluno);
            }catch(Exception ex){
                if (ex.Message == "Aluno não encontrado"){
                    return NotFound("Aluno não encontrado.");
                }
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAluno([FromRoute]int id, [FromBody] Aluno aluno){
             if (id != aluno.Id){
                return BadRequest("Turma não encontrada.");
            }
            try{
                _alunoService.UpdateAluno(aluno);
                return Ok(aluno);
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAluno(int id){
            try{
                _alunoService.DeleteAluno(id);
                return Ok("Aluno deletado.");
            }
            catch (Exception ex){
                if (ex.Message == "Aluno não encontrado"){
                    return NotFound("Aluno não encontrado.");
                }
                else{
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}