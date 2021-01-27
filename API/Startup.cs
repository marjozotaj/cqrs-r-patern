using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.PhoneBook;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Hosting;
using Presistence.DAL;
using System.Text.Json.Serialization;
using System.IO;
using System.Reflection;
using System;

namespace API
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
            
            services.AddControllers();
            services.AddScoped<IPhoneBookRepository<Domain.PhoneBook>, PhoneBookRepository<Domain.PhoneBook>>();
            
          
            services.AddMediatR(typeof(List.Handler).Assembly);
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                var xmlPathApplication = Path.Combine(AppContext.BaseDirectory, "Application.xml");
                var xmlPathDomain = Path.Combine(AppContext.BaseDirectory, "Domain.xml");
                c.IncludeXmlComments(xmlPath);
                c.IncludeXmlComments(xmlPathApplication);
                c.IncludeXmlComments(xmlPathDomain);
              
            });
            
         services.AddControllersWithViews()
                .AddJsonOptions(options => 
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                 app.UseSwaggerUI(c =>
               {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    c.RoutePrefix = string.Empty;
                });
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
