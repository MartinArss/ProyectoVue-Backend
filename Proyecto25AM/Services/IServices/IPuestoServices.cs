using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IPuestoServices
    {
        public Task<Response<List<Puesto>>> GetPt();

        public ActionResult<Response<Puesto>> ObtenerPtId(int id);

        public Task<Response<Puesto>> CrearPt(PuestoResponse request);

        public Task<Response<Puesto>> ActualizarPt(int id, [FromBody] PuestoResponse i);

        public Task<Response<Puesto>> EliminarPt(int id);
    }
}
