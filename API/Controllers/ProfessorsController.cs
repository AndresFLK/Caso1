using Application.Professors;
using Domain.Professor;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private IProfessorService _service;

        public ProfessorsController(IProfessorService service)
        {
            _service = service;
        }

        //-------------Professors LIST GET---------------- EROR 500
        public IActionResult List()
        {
            var result = _service.List();

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, null);
        }

        //-------------Professors q GET---------------- ERROR 404
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id) { 
            if (id == 0)
            {
                   return BadRequest();
            }
            
            var result = _service.Get(id);
            if (result.IsSuccess)
            {
                   return Ok(result.Value);
            }
            return NotFound();
        }

        ///-------------Professors POST---------------- ERROR 500
        [HttpPost]
        public IActionResult Create([FromBody] CreateProfessor professor)
        {
            var result = _service.Create(professor);
            if (result.IsSuccess)
            {
                return Created();
            }
            return StatusCode(StatusCodes.Status500InternalServerError, null);
        }

        //-------------Professors PUT---------------- ERROR 500
        [HttpPut]
        public IActionResult Update([FromBody] UpdateProfessor professor)
        {
            var result = _service.Update(professor);

            if (result.IsSuccess)
            {
                return Accepted();
            }

            if (result.Error == ProfessorErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        //-------------Professors DELETE---------------- ERROR 500
        [HttpDelete]
        [DisableCors]
        public IActionResult Delete([FromQuery] int id)
        {
            var result = _service.Delete(id);

            if (result.IsSuccess)
            {
                return NoContent();
            }

            if (result.Error == ProfessorErrors.NotFound())
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status500InternalServerError, null);
        }

    }//fin de la clase ProfessorsController
}//fin del namespace API.Controllers
