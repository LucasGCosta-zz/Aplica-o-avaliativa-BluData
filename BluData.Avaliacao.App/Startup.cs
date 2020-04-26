using BluData.Avaliacao.App.Extensions;
using BluData.Avaliacao.App.Models;
using BluData.Avaliacao.Database.DAL;
using BluData.Avaliacao.Database.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BluData.Avaliacao.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize);

            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddDbContext<BluDataContext>(options =>
                options.UseMySql(Configuration["BluDataConnection:MySql"]));

            services.AddMvc(options => options.EnableEndpointRouting = false)
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddScoped<IRepository<Empresa>, EmpresaRepository>();
            services.AddScoped<IRepository<Fornecedor>, FornecedorRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BluDataContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.ConfigureExceptionHandler();
            
            app.UseAuthorization();

            app.UseCors("AllowAll");

            app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            context.Database.Migrate();
        }
    }
}
