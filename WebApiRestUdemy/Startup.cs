using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WebApiRestUdemy.Data;
using WebApiRestUdemy.Data.Mapping;
using WebApiRestUdemy.Hypermedia.Enricher;
using WebApiRestUdemy.Hypermedia.Filters;
using WebApiRestUdemy.Repository;

namespace WebApiRestUdemy
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
            var connection = Configuration.GetConnectionString("MySqlConnection");

            services.AddControllers();

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IBookRepository, BookRepository>();

            services.AddDbContext<DataContext>(options =>
                options.UseMySql(connection,ServerVersion.AutoDetect(connection)));

            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
            filterOptions.ContentResponseEnricherList.Add(new BookEnricher());

            services.AddSingleton(filterOptions);

            services.AddApiVersioning();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                         Title = "Rest Api .NET Core 5 and Docker",
                         Version = "v1",
                         Description =  "Api RestFull Developed in Course",
                         Contact =  new Microsoft.OpenApi.Models.OpenApiContact
                         {
                             Name = "Lucas De Micco",
                             Url = new Uri("https://github.com/lucasdemicco")
                         }

                    });
                });
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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","Rest Api .NET Core 5 and Docker - v1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
            });
        }
    }
}
