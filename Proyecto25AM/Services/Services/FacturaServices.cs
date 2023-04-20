using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class FacturaServices : IFacturaServices
    {
        private readonly ApplicationDBContext _context;

        public string Mensaje;

        public FacturaServices(ApplicationDBContext context)
        {
            _context = context;
        }

        //Creación de funciones CRUD

        //Lista de facturas completa
        public async Task<Response<List<Factura>>> GetFac()
        {
            try
            {

                var res = await _context.Facturas.Include(x => x.Cliente).ToListAsync();

                if (res.Count > 0)
                {
                    return new Response<List<Factura>>(res);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<List<Factura>>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("surgio un error: " + ex.Message);
            }
        }

        //Facturas por id
        public ActionResult<Response<Factura>> ObtenerFacId(int id)
        {
            var res = _context.Facturas.Find(id);
            try
            {
                if (res != null)
                {
                    res = _context.Facturas.FirstOrDefault(x => x.PkFactura == id);
                    return new Response<Factura>(res);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<Factura>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }

        }

        public async Task<Response<Factura>> CrearFac(FacturaResponse request)
        {
            try
            {
                Factura Fac = new Factura()
                {
                    RazonSocial = request.RazonSocial,
                    Fecha = request.Fecha,
                    RFC = request.RFC,
                    FkCliente = request.FkCliente

                };

                _context.Facturas.Add(Fac);
                await _context.SaveChangesAsync();

                return new Response<Factura>(Fac);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }

        public async Task<Response<Factura>> ActualizarFac(int id, [FromBody] FacturaResponse i)
        {
            try
            {
                var res = _context.Facturas.Find(id);
                if (res != null)
                {
                    res.RazonSocial = i.RazonSocial;
                    res.Fecha = i.Fecha;
                    res.RFC = i.RFC;
                    res.FkCliente = i.FkCliente;

                    _context.Facturas.Update(res);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    Mensaje = "No se encontro la factura";
                    return new Response<Factura>(Mensaje);
                }

                return new Response<Factura>(res);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }

        public async Task<Response<Factura>> EliminarFac(int id)
        {
            var res = _context.Facturas.Find(id);

            if (res != null)
            {

                _context.Facturas.Remove(res);
                await _context.SaveChangesAsync();
                return new Response<Factura>(res);

            }
            else
            {
                Mensaje = "No se encontro la factura";
                return new Response<Factura>(Mensaje);
            }

        }

    }
}
