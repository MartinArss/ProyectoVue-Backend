using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IFacturaServices
    {
        public Task<Response<List<Factura>>> GetFac();

        public ActionResult<Response<Factura>> ObtenerFacId(int id);

        public Task<Response<Factura>> CrearFac(FacturaResponse request);

        public Task<Response<Factura>> ActualizarFac(int id, [FromBody] FacturaResponse i);

        public Task<Response<Factura>> EliminarFac(int id);
    }
}
