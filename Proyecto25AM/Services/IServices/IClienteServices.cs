using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IClienteServices
    {
        public Task<Response<List<Cliente>>> GetCli();

        public ActionResult<Response<Cliente>> ObtenerCliId(int id);

        public Task<Response<Cliente>> CrearCliente(ClienteResponse request);

        public Task<Response<Cliente>> ActualizarCli(int id, [FromBody] ClienteResponse i);

        public Task<Response<Cliente>> EliminarCli(int id);
    }
}
