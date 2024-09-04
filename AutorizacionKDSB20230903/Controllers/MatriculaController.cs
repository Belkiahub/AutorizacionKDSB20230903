using AutorizacionKDSB20230903.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutorizacionKDSB20230903.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        static List<Matricula> matricula = new List<Matricula>();
        // GET: api/<MatriculaController>
        [Authorize]
        [HttpGet]
        public IEnumerable<Matricula> Get()
        {
            return matricula;
        }

        // GET api/<MatriculaController>/5
        [Authorize]
        [HttpGet("{id}")]
        public Matricula Get(int id)
        {
            var matric = matricula.FirstOrDefault(c => c.Id == id);
            return matric;
        }

        // POST api/<MatriculaController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] Matricula matriculas)
        {
            matricula.Add(matriculas);
            return Ok();
        }

        // PUT api/<MatriculaController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Matricula matriculas)
        {
            var existingMatric = matricula.FirstOrDefault(c => c.Id == id);
            if (existingMatric != null)
            {
                existingMatric.estudiante = matriculas.estudiante;
                existingMatric.estado = matriculas.estado;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<MatriculaController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingMatric = matricula.FirstOrDefault(c => c.Id == id);
            if (existingMatric != null)
            {
                matricula.Remove(existingMatric);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
