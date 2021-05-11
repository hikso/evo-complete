using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace EVO_PV_WebApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "1.0.0",
                    Title = "EVO - Colección de APIs",
                    Description = "Colección de APIs del proyecto EVO (ASP.NET Core 3.1)",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Antioqueña de Porcinos",
                        Url = new Uri("https://www.porcicarnes.com"),
                        Email = "no-responder@porcicarnes.com"
                    },
                    TermsOfService = new Uri("https://www.porcicarnes.com")
                });
            });

            //services.AddHttpContextAccessor();

            //Se obtiene del appsettings.json, la sección: AllowedOrigins, la propiedad: URLS, que contiene un array de strings, en dónde cada string
            //es una URL a habilitar para CORS
            string[] allowedOrigins = Configuration.GetSection("AllowedOrigins").GetSection("URLS").Get<string[]>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder => builder.WithOrigins(allowedOrigins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithMethods("GET", "POST", "DELETE", "PUT")
                    );
            });

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });            

            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            services.AddControllers();
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(string.Format("/{0}/swagger/v1/swagger.json", env.ApplicationName), "EVO - Colección de APIs");
            });

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}