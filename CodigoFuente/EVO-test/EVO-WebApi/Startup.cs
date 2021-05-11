using AutoMapper;
using EVO_WebApi.Filters;
using EVO_WebApi.Models.AutoMapperConfig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace EVO_WebApi
{/// <summary>
/// 
/// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        /// <param name="configuration"></param>
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            _hostingEnv = env;
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnv;

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("1.0.0", new Info
                    {
                        Version = "1.0.0",
                        Title = "EVO - Colección de APIs",
                        Description = "Colección de APIs del proyecto EVO (ASP.NET Core 2.1)",
                        Contact = new Contact()
                        {
                            Name = "Antioqueña de Porcinos",
                            Url = "http://www.porcicarnes.com/",
                            Email = "no-responder@porcicarnes.com"
                        },
                        TermsOfService = "http://www.porcicarnes.com/"
                    });
                    c.CustomSchemaIds(type => type.FriendlyId(true));
                    c.DescribeAllEnumsAsStrings();
                    c.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{_hostingEnv.ApplicationName}.xml");

                    // Sets the basePath property in the Swagger document generated
                    c.DocumentFilter<BasePathFilter>(string.Format("/{0}", _hostingEnv.ApplicationName));

                    // Include DataAnnotation attributes on Controller Action parameters as Swagger validation rules (e.g required, pattern, ..)
                    // Use [ValidateModelState] on Actions to actually validate it in C# as well!
                    c.OperationFilter<GeneratePathParamsValidationFilter>();


                });

            //Se habilita el automapper
            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            var mapper = configMapper.CreateMapper();

            services.AddSingleton(mapper);

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
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAuthentication(IISDefaults.AuthenticationScheme);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    app.UseStatusCodePagesWithRedirects("/motivos/");
                    // context.Request.Path = "/api/motivos";
                    await next();
                }
            });
            // Make sure you call this before calling app.UseMvc()
            var locale = Configuration["SiteLocale"];

            RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions
            {
                SupportedCultures = new List<CultureInfo> { new CultureInfo(locale) },
                SupportedUICultures = new List<CultureInfo> { new CultureInfo(locale) },
                DefaultRequestCulture = new RequestCulture(locale)
            };

            app.UseRequestLocalization(localizationOptions);

            app.UseCors();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(string.Format("/{0}/swagger/1.0.0/swagger.json", env.ApplicationName), "API de Auditoria");
            });

            app.UseMvc();
            app.UseAuthentication();


        }



    }
}


