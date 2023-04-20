using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IUsuarioServices
    {
        public Task<Response<List<Usuario>>> GetUsers();

        public ActionResult<Response<Usuario>> ObtenerUserId(int id);

        public Task<Response<Usuario>> CrearUsuario(UsuarioResponse request);

        public Task<Response<Usuario>> ActualizarUser(int id, [FromBody] UsuarioResponse i);

        public Task<Response<Usuario>> EliminarUser(int id);
    }
}
