using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteHavan.Application;
using TesteHavan.Application.Contracts;
using TesteHavan.Infrastructure;
using TesteHavan.Infrastructure.Context;
using TesteHavan.Infrastructure.Contracts;

namespace TesteHavan
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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //AddTransient => Parte da Solução para todas as vezes que chamar o "Connection" do context (TesteHavanContext) pois, todas as conexões solicitadas após a primeira, o "Connection" vinha como null.
            //Outra parte foi a chamada, abertura e fechamento da conexão dentro de cada método que precisa da conexão com o BD.
            services.AddTransient<TesteHavanContext>();            

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ITicketSituacaoService, TicketSituacaoService>();
            services.AddScoped<ITicketAnotacoesService, TicketAnotacoesService>();
            services.AddScoped<IViewBDService, ViewBDService>();

            services.AddScoped<IClienteRepo, ClienteRepo>();
            services.AddScoped<IUsuarioRepo, UsuarioRepo>();
            services.AddScoped<ITicketRepo, TicketRepo>();
            services.AddScoped<ITicketSituacaoRepo, TicketSituacaoRepo>();
            services.AddScoped<ITicketAnotacoesRepo, TicketAnotacoesRepo>();
            services.AddScoped<IViewRepo, ViewRepo>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TesteHavan", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TesteHavan v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
