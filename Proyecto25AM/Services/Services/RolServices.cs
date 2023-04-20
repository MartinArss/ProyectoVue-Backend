using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class RolServices : IRolServices
    {
        private readonly ApplicationDBContext _context;

        public string Mensaje;

        public RolServices(ApplicationDBContext context)
        {
            _context = context;
        }

        //Creación de funciones CRUD

        //Lista de roles completa
        public async Task<Response<List<Rol>>> GetRol()
        {
            try
            {

                var res = await _context.Rols.ToListAsync();

                if (res.Count > 0)
                {
                    return new Response<List<Rol>>(res);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<List<Rol>>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("surgio un error: " + ex.Message);
            }
        }

        //Rol por id
        public ActionResult<Response<Rol>> ObtenerRolId(int id)
        {
            var res = _context.Rols.Find(id);
            try
            {
                if (res != null)
                {
                    res = _context.Rols.FirstOrDefault(x => x.PkRol == id);
                    return new Response<Rol>(res);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<Rol>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }

        }

        public async Task<Response<Rol>> CrearRol(RolResponse request)
        {
            try
            {
                Rol Rl = new Rol()
                {
                    Nombre = request.Nombre

                };

                _context.Rols.Add(Rl);
                await _context.SaveChangesAsync();

                return new Response<Rol>(Rl);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }

        public async Task<Response<Rol>> ActualizarRol(int id, [FromBody] RolResponse i)
        {
            try
            {
                var res = _context.Rols.Find(id);
                if (res != null)
                {
                    res.Nombre = i.Nombre;

                    _context.Rols.Update(res);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    Mensaje = "No se encontro el rol";
                    return new Response<Rol>(Mensaje);
                }

                return new Response<Rol>(res);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }

        public async Task<Response<Rol>> EliminarRol(int id)
        {
            var res = _context.Rols.Find(id);

            if (res != null)
            {

                _context.Rols.Remove(res);
                await _context.SaveChangesAsync();
                return new Response<Rol>(res);

            }
            else
            {
                Mensaje = "No se encontro el rol";
                return new Response<Rol>(Mensaje);
            }

        }
    }
}
