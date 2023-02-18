using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinoSiteApi.Repositorios;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TreinoSiteApi.Services;
using Microsoft.EntityFrameworkCore;
using TreinoSiteApi.Modulos;

namespace TreinoSiteApi
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
            services.AddDbContext<ProdutoContexto>(options => 
                      options.UseSqlServer(Configuration.GetConnectionString("conexaoSqlServer")));

            services.AddControllers();
            services.AddScoped<IUsuarioClienteRepositorioSql, UsuarioClienteRepositorioSql>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddScoped<ProdutoContexto>();

            services.AddHttpContextAccessor();

            var conexao = Configuration.GetConnectionString("App");

            var tokenConfiguration = Configuration["TokenConfiguration"];
            var key = Encoding.ASCII.GetBytes(tokenConfiguration);

            services.AddAuthentication(x =>
            {

                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => 
            {

                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            
            });



             


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ProdutoContexto contexto)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=TreinoSiteApi}/{action=Gets}/{id?}");

                endpoints.MapControllerRoute(name: "Produtos",
                pattern: "{controller=Produtos}/{action=Index}/{id?}",
                defaults: new { controller = "Produtos", action = "Index" });


               // endpoints.MapControllers();
            });
            InicializaDB.Inicializa(contexto);
        }
    }
}
