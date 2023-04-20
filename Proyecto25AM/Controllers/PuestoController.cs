using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PuestoController : Controller
    {
        private readonly IPuestoServices _puestoServices;

        public PuestoController(IPuestoServices puestoServices)
        {
            _puestoServices = puestoServices;
        }

        //Lista puesto
        [HttpGet]
        public async Task<IActionResult> GetPuesto()
        {
            return Ok(await _puestoServices.GetPt());
        }

        //Obtener departamentos por id
        [HttpGet("ID")]
        public ActionResult ObtenerDepaID(int id)
        {
            return Ok( _puestoServices.ObtenerPtId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] PuestoResponse i)
        {
            return Ok(await _puestoServices.CrearPt(i));
        }


        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] PuestoResponse i, int id)
        {
            return Ok(await _puestoServices.ActualizarPt(id, i));
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _puestoServices.EliminarPt(id));
        }

    }
}
