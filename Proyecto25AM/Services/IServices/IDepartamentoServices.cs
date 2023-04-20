using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IDepartamentoServices
    {
        public Task<Response<List<Departamento>>> GetDeparta();

        public ActionResult<Response<Departamento>> ObtenerDepaId(int id);

        public Task<Response<Departamento>> CrearDepa(DepartamentoResponse request);

        public Task<Response<Departamento>> ActualizarDepa(int id, [FromBody] DepartamentoResponse i);

        public Task<Response<Departamento>> EliminarDepa(int id);
    }
}
