using Microsoft.AspNetCore.Mvc;
using tech_test_api.Models;
using tech_test_api.Services;
using tech_test_api.Dtos;


namespace tech_test_api.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class TurmaController:ControllerBase{
        private readonly ITurmaService _turmaService;
        
        public TurmaController(ITurmaService  turmaService){
        _turmaService = turmaService;
        }

        [HttpPost]
        public ActionResult<TurmaDto> AddTurma([FromBody] TurmaDto turma){  
            try{
                _turmaService.AddTurma(turma);
                return CreatedAtAction(nameof(GetById), new { id = turma.Id }, turma);
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Turma>> GetAllTurmas(){
            var turmas = _turmaService.GetTurmas();
            return Ok(turmas);
        }

        [HttpGet("{id}")]
        public ActionResult<Turma> GetById(int id){
            var turma = _turmaService.GetTurmaById(id);
            try{
                return Ok(turma);
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTurma([FromRoute]int id, [FromBody] Turma turma){
            if (id != turma.Id){
                return BadRequest("Turma não encontrada.");
            }
            try{
                _turmaService.UpdateTurma(turma);
                return Ok(turma);
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTurma(int id){
            try{
                _turmaService.DeleteTurma(id);
                return Ok("Turma deletada.");
            }
            catch (Exception ex){
                if (ex.Message == "Turma não encontrada"){
                    return NotFound("Turma não encontrada.");
                }
                else{
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}