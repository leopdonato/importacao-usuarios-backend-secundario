using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImportacaoUsuarios.Models.Context;
using ImportacaoUsuarios.Repositories;
using ImportacaoUsuarios.Repositories.Implementations;
using ImportacaoUsuarios.Services;
using ImportacaoUsuarios.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ImportacaoUsuarios
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
            var connection = Configuration["SqlServerConnection:SqlServerConnectionString"];
            services.AddDbContext<UsuarioContext>(options => options.UseSqlServer(connection));

            services.AddControllers();

            //Dependency Injection
            services.AddScoped<IUsuarioIntermediarioRepository, UsuarioIntermediarioRepositoryImp>();
            services.AddScoped<IUsuarioIntermediarioService, UsuarioIntermediarioServiceImp>();
            services.AddScoped<IUsuarioRepository, UsuarioRepositoryImp>();
            services.AddScoped<IUsuarioService, UsuarioServiceImp>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
