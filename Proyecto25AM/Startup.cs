using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;
using Proyecto25AM.Services.Services;

namespace Proyecto25AM
{
    public class Startup
    {
        // MARTIN MARTINEZ ARIAS
        // Creo mi variable
        private readonly string _Politicas = "MyCors";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; set; }   

        public void ConfigureServices(IServiceCollection services)
        {
            //add ConectionDTB
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Inyeccion de dependencias
            services.AddTransient<IUsuarioServices, UsuarioServices>();
            services.AddTransient<IClienteServices, ClienteServices>();
            services.AddTransient<IDepartamentoServices, DepartamentoServices>();
            services.AddTransient<IEmpleadoServices, EmpleadoServices>();
            services.AddTransient<IFacturaServices, FacturaServices>();
            services.AddTransient<IPuestoServices, PuestoServices>();
            services.AddTransient<IRolServices, RolServices>();
            

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Implementacion de MyCors Martin Maritnez Arias
            services.AddCors(options =>
            {
                // Llamo a la variable
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:5173") // Le digo que permita cualquier origen, de acuerdo
                        .AllowAnyHeader()    // de acuerdo a mi investigacion
                        .AllowAnyMethod();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Implementacion de Cors
            app.UseCors("CorsPolicy");

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });

        }



    }
}   
