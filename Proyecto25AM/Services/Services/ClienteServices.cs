using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly ApplicationDBContext _context;
        public string Mensaje;
        public ClienteServices(ApplicationDBContext context)
        {
            _context = context;
        }

        //Creación de funciones CRUD


        //Lista de clientes completa
        public async Task<Response<List<Cliente>>> GetCli()
        {
            try
            {

                var res = await _context.Clientes.ToListAsync();

                if (res.Count > 0)
                {
                    return new Response<List<Cliente>>(res);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<List<Cliente>>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("surgio un error: " + ex.Message);
            }
        }

        //Clientes por id
        public ActionResult<Response<Cliente>> ObtenerCliId(int id)
        {
            var res = _context.Clientes.Find(id);
            try
            {
                if (res != null)
                {
                    res = _context.Clientes.FirstOrDefault(x => x.PkCliente == id);
                    return new Response<Cliente>(res);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<Cliente>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }

        public async Task<Response<Cliente>> CrearCliente(ClienteResponse request)
        {
            try
            {
                Cliente cli = new Cliente()
                {
                    Nombre = request.Nombre,
                    Apellidos = request.Apellidos,
                    Telefono = request.Telefono,
                    Email = request.Email,
                    Direccion = request.Direccion
                };

                _context.Clientes.Add(cli);
                await _context.SaveChangesAsync();

                return new Response<Cliente>(cli);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }

        public async Task<Response<Cliente>> ActualizarCli(int id, [FromBody] ClienteResponse i)
        {
            try
            {
                var res = _context.Clientes.Find(id);
                if (res != null)
                {
                    res.Nombre = i.Nombre;
                    res.Apellidos = i.Apellidos;
                    res.Telefono = i.Telefono;
                    res.Email = i.Email;
                    res.Direccion = i.Direccion;

                    _context.Clientes.Update(res);
                    await _context.SaveChangesAsync();
                   
                }
                else
                {
                    Mensaje = "No se encontro el cliente";
                    return new Response<Cliente>(Mensaje);
                }

                return new Response<Cliente>(res);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }

        public async Task<Response<Cliente>> EliminarCli(int id)
        {
            var res = _context.Clientes.Find(id);

            if (res != null)
            {

                _context.Clientes.Remove(res);
                await _context.SaveChangesAsync();
                return new Response<Cliente>(res);

            }
            else
            {
                Mensaje = "No se encontro el cliente";
                return new Response<Cliente>(Mensaje);
            }

        }
    }
}
