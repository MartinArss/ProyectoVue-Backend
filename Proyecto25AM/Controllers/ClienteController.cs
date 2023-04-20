using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteServices _clienteServices;

        public ClienteController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        //Lista de usuarios
        [HttpGet]
        public async Task<IActionResult> GetCliente()
        {
            return Ok(await _clienteServices.GetCli());
        }

        //Obtener clientes por id
        [HttpGet("ID")]
        public ActionResult ObtenerCliID(int id)
        {
            return Ok(_clienteServices.ObtenerCliId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ClienteResponse i)
        {
            return Ok(await _clienteServices.CrearCliente(i));
        }


        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] ClienteResponse i, int id)
        {
            return Ok(await _clienteServices.ActualizarCli(id, i));
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _clienteServices.EliminarCli(id));
        }
    }
}
