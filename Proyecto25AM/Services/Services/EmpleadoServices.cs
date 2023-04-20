using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class EmpleadoServices: IEmpleadoServices
    {
        private readonly ApplicationDBContext _context;

        public string Mensaje;

        public EmpleadoServices(ApplicationDBContext context)
        {
            _context = context;
        }

        //Creación de funciones CRUD

        //Lista de empleados completa
        public async Task<Response<List<Empleado>>> GetEmp()
        {
            try
            {

                var res = await _context.Empleados.Include(x => x.Puesto).Include(y => y.Departamento).ToListAsync();   //ToListAsync();
                //var order = dbContext.Orders
                //                .Include(o => o.Customer)+
                //                .FirstOrDefault(o => o.OrderId == orderId);
                //int customerId = order.Customer.CustomerId;



                if (res.Count > 0)
                {
                    return new Response<List<Empleado>>(res);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<List<Empleado>>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("surgio un error: " + ex.Message);
            }
        }

        //Empleados por id
        public ActionResult<Response<Empleado>> ObtenerEmpId(int id)
        {
            var res = _context.Empleados.Find(id);
            try
            {
                if (res != null)
                {
                    res = _context.Empleados.FirstOrDefault(x => x.PkEmpleado == id);
                    return new Response<Empleado>(res);
                }
                else
                {
                    Mensaje = "No se encontro ningún registro";
                    return new Response<Empleado>(Mensaje);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }

        }

        public async Task<Response<Empleado>> CrearEmp(EmpleadoResponse request)
        {
            try
            {
                Empleado Emp = new Empleado()
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    Direccion = request.Direccion,
                    Ciudad = request.Ciudad,
                    FkPuesto = request.FkPuesto,
                    FkDepartamento = request.FkDepartamento

                };

                _context.Empleados.Add(Emp);
                await _context.SaveChangesAsync();

                return new Response<Empleado>(Emp);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }

        public async Task<Response<Empleado>> ActualizarEmp(int id, [FromBody] EmpleadoResponse i)
        {
            try
            {
                var res = _context.Empleados.Find(id);
                if (res != null)
                {
                    res.Nombre = i.Nombre;
                    res.Apellido = i.Apellido;
                    res.Direccion = i.Direccion;
                    res.Ciudad = i.Ciudad;
                    res.FkPuesto = i.FkPuesto;
                    res.FkDepartamento = i.FkDepartamento;

                    _context.Empleados.Update(res);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    Mensaje = "No se encontro el empleado";
                    return new Response<Empleado>(Mensaje);
                }

                return new Response<Empleado>(res);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }

        public async Task<Response<Empleado>> EliminarEmp(int id)
        {
            var res = _context.Empleados.Find(id);

            if (res != null)
            {

                _context.Empleados.Remove(res);
                await _context.SaveChangesAsync();
                return new Response<Empleado>(res);

            }
            else
            {
                Mensaje = "No se encontro el empleado";
                return new Response<Empleado>(Mensaje);
            }

        }
    }
}
