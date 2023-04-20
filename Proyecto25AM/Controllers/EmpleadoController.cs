using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoServices _empleadoServices;

        public EmpleadoController(IEmpleadoServices empleadoServices)
        {
            _empleadoServices = empleadoServices;
        }

        //Lista de empleados
        [HttpGet]
        public async Task<IActionResult> GetEmpleados()
        {
            return Ok(await _empleadoServices.GetEmp());
        }

        //Obtener empleados por id
        [HttpGet("ID")]
        public ActionResult ObtenerEmpID(int id)
        {
            return Ok(_empleadoServices.ObtenerEmpId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] EmpleadoResponse i)
        {
            return Ok(await _empleadoServices.CrearEmp(i));
        }


        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] EmpleadoResponse i, int id)
        {
            return Ok(await _empleadoServices.ActualizarEmp(id, i));
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _empleadoServices.EliminarEmp(id));
        }
    }
}
