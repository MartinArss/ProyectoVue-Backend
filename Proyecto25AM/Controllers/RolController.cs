using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolController : Controller
    {
        
        private readonly IRolServices _rolServices;

        public RolController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }

        //Lista puesto
        [HttpGet]
        public async Task<IActionResult> GetPuesto()
        {
            return Ok(await _rolServices.GetRol());
        }

        //Obtener departamentos por id
        [HttpGet("ID")]
        public ActionResult ObtenerDepaID(int id)
        {
            return Ok( _rolServices.ObtenerRolId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] RolResponse i)
        {
            return Ok(await _rolServices.CrearRol(i));
        }


        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] RolResponse i, int id)
        {
            return Ok(await _rolServices.ActualizarRol(id, i));
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _rolServices.EliminarRol(id));
        }

    }
}
