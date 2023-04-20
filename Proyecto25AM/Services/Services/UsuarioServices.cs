using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;
using static Proyecto25AM.Services.Services.UsuarioServices;

namespace Proyecto25AM.Services.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDBContext _context;
        public string Mensaje;

        public UsuarioServices(ApplicationDBContext context)
        {
            _context = context;
        }

        //Creación de funciones CRUD

        //Lista de usuarios completa
        public async Task<Response<List<Usuario>>> GetUsers()
        {
            try
            {

                var response = await _context.Usuarios.Include(x => x.Empleado).Include(y => y.Rol).ToListAsync();

                if (response.Count > 0)
                {
                    return new Response<List<Usuario>>(response);
                }
                else
                {
                    Mensaje = "no se encontro ningún registro";
                    return new Response<List<Usuario>>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("surgio un error: " + ex.Message);
            }
        }

        //Usuarios por id

        public ActionResult<Response<Usuario>> ObtenerUserId(int id)
        {
            var res = _context.Usuarios.Find(id);
            try
            {
                if (res != null)
                {
                    res = _context.Usuarios.FirstOrDefault(x => x.PkUsuario == id);
                    return new Response<Usuario>(res);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<Usuario>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }

        public async Task<Response<Usuario>> CrearUsuario(UsuarioResponse request)
        {
            try
            {
                Usuario user = new Usuario()
                {
                    User = request.User,
                    Password = request.Password,
                    FechaRegistro = request.FechaRegistro,
                    FkEmpleado = request.FkEmpleado,
                    FkRol = request.FkRol
                };


                _context.Usuarios.Add(user);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(user);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }   

        public async Task<Response<Usuario>> ActualizarUser(int id,[FromBody] UsuarioResponse i)
        {
            try
            {
                var res = _context.Usuarios.Find(id);
                if (res != null)
                {
                    res.User = i.User;
                    res.Password = i.Password;
                    res.FechaRegistro = i.FechaRegistro;
                    res.FkEmpleado = i.FkEmpleado;
                    res.FkRol = i.FkRol;

                    _context.Usuarios.Update(res);
                    await _context.SaveChangesAsync();


                }
                else
                {
                    Mensaje = "No se encontro el usuario";
                    return new Response<Usuario>(Mensaje);
                }

                return new Response<Usuario>(res);
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }

        public async Task<Response<Usuario>> EliminarUser(int id)
        {
            var res = _context.Usuarios.Find(id);

            if (res != null )
            {
                
                _context.Usuarios.Remove(res);
                await _context.SaveChangesAsync();
                return new Response<Usuario>(res);

            }
            else
            {
                Mensaje = "No se encontro el usuario";
                return new Response<Usuario>(Mensaje);
            }

        }
    }
}
