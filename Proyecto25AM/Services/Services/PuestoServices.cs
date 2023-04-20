using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class PuestoServices : IPuestoServices
    {
        private readonly ApplicationDBContext _context;

        public string Mensaje;

        public PuestoServices(ApplicationDBContext context)
        {
            _context = context;
        }

        //Creación de funciones CRUD


        //Lista de departamentos completa
        public async Task<Response<List<Puesto>>> GetPt()
        {
            try
            {

                var res = await _context.Puestos.ToListAsync();

                if (res.Count > 0)
                {
                    return new Response<List<Puesto>>(res);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<List<Puesto>>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("surgio un error: " + ex.Message);
            }
        }

        //Puesto por id
        public ActionResult<Response<Puesto>> ObtenerPtId(int id)
        {
            var res = _context.Puestos.Find(id);
            try
            {
                if (res != null)
                {
                    res = _context.Puestos.FirstOrDefault(x => x.PkPuesto == id);
                    return new Response<Puesto>(res);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<Puesto>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }

        }

        public async Task<Response<Puesto>> CrearPt(PuestoResponse request)
        {
            try
            {
                Puesto PT = new Puesto()
                {
                    Nombre = request.Nombre

                };

                _context.Puestos.Add(PT);
                await _context.SaveChangesAsync();

                return new Response<Puesto>(PT);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }

        public async Task<Response<Puesto>> ActualizarPt(int id, [FromBody] PuestoResponse i)
        {
            try
            {
                var res = _context.Puestos.Find(id);
                if (res != null)
                {
                    res.Nombre = i.Nombre;

                    _context.Puestos.Update(res);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    Mensaje = "No se encontro el puesto";
                    return new Response<Puesto>(Mensaje);
                }

                return new Response<Puesto>(res);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }

        public async Task<Response<Puesto>> EliminarPt(int id)
        {
            var res = _context.Puestos.Find(id);

            if (res != null)
            {

                _context.Puestos.Remove(res);
                await _context.SaveChangesAsync();
                return new Response<Puesto>(res);

            }
            else
            {
                Mensaje = "No se encontro el puesto";
                return new Response<Puesto>(Mensaje);
            }

        }
    }
}
