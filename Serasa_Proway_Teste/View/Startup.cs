using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Modelos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Servicos.Interfaces;
using Servicos.Repositorios;
using Servicos.ViewModel;

namespace View
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IFileProvider>(
           new PhysicalFileProvider(
               Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            services.AddDbContext<EmpresaRatingDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection"),
                 options => options.MigrationsAssembly("Servicos"));

            });

            services.AddControllers().AddNewtonsoftJson(options =>
             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            services.AddCors();


            #region Injeção de Dependencias

            services.AddTransient(typeof(IEmpresaRepositorio), typeof(EmpresaRepositorio));
            services.AddTransient(typeof(IDebitoRepositorio), typeof(DebitoRepositorio));
            services.AddTransient(typeof(INotasFiscaisRepositorio), typeof(NotaFiscalRepositorio));

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, EmpresaRatingDbContext db)
        {
            app.UseCors(options => options.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            db.Database.EnsureCreated();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
