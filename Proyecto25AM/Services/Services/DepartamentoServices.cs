using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class DepartamentoServices : IDepartamentoServices
    {
        private readonly ApplicationDBContext _context;

        public string Mensaje;
        public DepartamentoServices(ApplicationDBContext context)
        {
            _context = context;
        }

        //Creación de funciones CRUD

        //Lista de departamentos completa
        public async Task<Response<List<Departamento>>> GetDeparta()
        {
            try
            {

                var res = await _context.Departamentos.ToListAsync();

                if (res.Count > 0)
                {
                    return new Response<List<Departamento>>(res);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<List<Departamento>>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("surgio un error: " + ex.Message);
            }
        }

        //Departamentos por id
        public ActionResult<Response<Departamento>> ObtenerDepaId(int id)
        {
            var res = _context.Departamentos.Find(id);
            try
            {
                if (res != null)
                {
                    res = _context.Departamentos.FirstOrDefault(x => x.PkDepartamento == id);
                    return new Response<Departamento>(res);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<Departamento>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }

        }

        public async Task<Response<Departamento>> CrearDepa(DepartamentoResponse request)
        {
            try
            {
                Departamento Depa = new Departamento()
                {
                    Nombre = request.Nombre

                };

                _context.Departamentos.Add(Depa);
                await _context.SaveChangesAsync();

                return new Response<Departamento>(Depa);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }

        public async Task<Response<Departamento>> ActualizarDepa(int id, [FromBody] DepartamentoResponse i)
        {
            try
            {
                var res = _context.Departamentos.Find(id);
                if (res != null)
                {
                    res.Nombre = i.Nombre;

                    _context.Departamentos.Update(res);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    Mensaje = "No se encontro el departamento";
                    return new Response<Departamento>(Mensaje);
                }

                return new Response<Departamento>(res);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }

        public async Task<Response<Departamento>> EliminarDepa(int id)
        {
            var res = _context.Departamentos.Find(id);

            if (res != null)
            {

                _context.Departamentos.Remove(res);
                await _context.SaveChangesAsync();
                return new Response<Departamento>(res);

            }
            else
            {
                Mensaje = "No se encontro el departamento";
                return new Response<Departamento>(Mensaje);
            }

        }
    }
}
