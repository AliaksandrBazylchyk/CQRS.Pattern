using System.Reflection;
using CQRS.Pattern.BLL.Mapping;
using CQRS.Pattern.BLL.Services.Person;
using CQRS.Pattern.Configurations;
using CQRS.Pattern.DAL.Repositories;
using CQRS.Pattern.DAL.Repositories.Mongo;
using CQRS.Pattern.DAL.Repositories.Npg;
using CQRS.Pattern.Extensions;
using CQRS.Pattern.Mapping;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace CQRS.Pattern
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
            // MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // Application configurations
            services.Configure<ConnectionOptions>(Configuration.GetSection(ConnectionOptions.SectionName));
            services.AddSingleton(x => x.GetRequiredService<IOptions<ConnectionOptions>>().Value);

            // Postgres and Mongo database initializer
            services.AddDbCollection(Configuration.GetSection(ConnectionOptions.SectionName).Get<ConnectionOptions>());

            // Application repositories
            services.AddScoped<IMongoPersonRepository, MongoPersonRepository>();
            services.AddScoped<INpgPersonRepository, NpgPersonRepository>();

            // Application services
            services.AddScoped(typeof(IPersonService), typeof(PersonService));

            // AutoMapper
            services.AddAutoMapper(typeof(AppBaseMappingProfile), typeof(BllBaseMappingProfile));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "CQRS.Pattern", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRS.Pattern v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}