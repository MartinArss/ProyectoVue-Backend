using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IEmpleadoServices
    {
        public Task<Response<List<Empleado>>> GetEmp();

        public ActionResult<Response<Empleado>> ObtenerEmpId(int id);

        public Task<Response<Empleado>> CrearEmp(EmpleadoResponse request);

        public Task<Response<Empleado>> ActualizarEmp(int id, [FromBody] EmpleadoResponse i);

        public Task<Response<Empleado>> EliminarEmp(int id);
    }
}
