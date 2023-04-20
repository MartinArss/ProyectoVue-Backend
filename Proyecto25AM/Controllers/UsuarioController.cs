using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;

        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        //Lista Usuarios
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _usuarioServices.GetUsers());
        }

        //Obtener usuarios por id
        [HttpGet("ID")]
        public ActionResult ObtenerUserID(int id)
        {
            return Ok( _usuarioServices.ObtenerUserId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] UsuarioResponse i)
        {
            return Ok(await _usuarioServices.CrearUsuario(i));
        }


        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] UsuarioResponse i, int id)
        {
            return Ok(await _usuarioServices.ActualizarUser(id, i));
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _usuarioServices.EliminarUser(id));
        }
    }
}
