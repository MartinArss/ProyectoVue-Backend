using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturaController : Controller
    {
        private readonly IFacturaServices _facturaServices;

        public FacturaController(IFacturaServices facturaServices)
        {
            _facturaServices = facturaServices;
        }

        //Lista Usuarios
        [HttpGet]
        public async Task<IActionResult> GetDepartamento()
        {
            return Ok(await _facturaServices.GetFac());
        }

        //Obtener departamentos por id
        [HttpGet("ID")]
        public ActionResult ObtenerDepaID(int id)
        {
            return Ok( _facturaServices.ObtenerFacId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] FacturaResponse i)
        {
            return Ok(await _facturaServices.CrearFac(i));
        }


        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] FacturaResponse i, int id)
        {
            return Ok(await _facturaServices.ActualizarFac(id, i));
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _facturaServices.EliminarFac(id));
        }


    }
}
