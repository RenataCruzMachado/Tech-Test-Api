using Microsoft.AspNetCore.Mvc;
using tech_test_api.Models;
using tech_test_api.Services;
using tech_test_api.Dtos;


namespace tech_test_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatriculaController:ControllerBase
    {
      
       private readonly IMatriculaService _matriculaService;

        public MatriculaController(IMatriculaService matriculaService ){
           
            _matriculaService = matriculaService;
        }

        [HttpPost]
        public ActionResult<MatriculaDto> AddMatricula([FromBody] MatriculaDto matricula){  
            try{
                _matriculaService.AddMatricula(matricula);
                return Ok(matricula);
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Matricula>> GetAllMatriculas(){
            var matriculas = _matriculaService.GetAllMatriculas();
            return Ok(matriculas);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMatricula(int id){
            try{
                _matriculaService.DeleteMatricula(id);
                return NoContent();
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }
    }
}