using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IRolServices
    {
        public Task<Response<List<Rol>>> GetRol();

        public ActionResult<Response<Rol>> ObtenerRolId(int id);

        public Task<Response<Rol>> CrearRol(RolResponse request);

        public Task<Response<Rol>> ActualizarRol(int id, [FromBody] RolResponse i);

        public Task<Response<Rol>> EliminarRol(int id);
    }
}
