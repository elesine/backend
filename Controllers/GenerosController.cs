using back_end.Entidades;
using back_end.repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace back_end.Controllers
{
    [Route("api/generos")]
    [ApiController]
    public class GenerosController: ControllerBase {

        private readonly IRepositorio repositorio;
        public GenerosController(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }
        [HttpGet]
        [HttpGet("listado")]
        public ActionResult<List<Genero>> Get()
        {
            return repositorio.ObternerTodosLosGeneros();
        }

        //        [HttpGet("{Id}")]
        [HttpGet("{Id}")]

        public async Task<ActionResult<Genero>> Get(int Id, [FromHeader] string nombre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var genero = await repositorio.ObtenerPorId(Id);

            if(genero == null)
            {
               return NotFound();
            }
            return genero;
        }
         
        [HttpPost]
        public ActionResult Post([FromBody] Genero genero)
        {
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {
            return NoContent();

        }
        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }


    }
}
