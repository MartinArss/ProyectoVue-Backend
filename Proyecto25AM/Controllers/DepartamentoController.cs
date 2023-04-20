using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoServices _departamentoServices;

        public DepartamentoController(IDepartamentoServices departamentoServices)
        {
            _departamentoServices = departamentoServices;
        }

        //Lista Usuarios
        [HttpGet]
        public async Task<IActionResult> GetDepartamento()
        {
            return Ok(await _departamentoServices.GetDeparta());
        }

        //Obtener departamentos por id
        [HttpGet("ID")]
        public ActionResult ObtenerDepaID(int id)
        {
            return Ok( _departamentoServices.ObtenerDepaId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] DepartamentoResponse i)
        {
            return Ok(await _departamentoServices.CrearDepa(i));
        }


        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] DepartamentoResponse i, int id)
        {
            return Ok(await _departamentoServices.ActualizarDepa(id, i));
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _departamentoServices.EliminarDepa(id));
        }


    }
}
