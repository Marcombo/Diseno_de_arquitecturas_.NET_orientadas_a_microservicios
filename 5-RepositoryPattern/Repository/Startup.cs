using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repository.Application.Services.Users;
using Repository.Domain.Interfaces.Repositories;
using Repository.Domain.Interfaces.Services.Users;
using Repository.Infrastructure.Repositories;

namespace Repository
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
            services.AddSingleton(typeof(IUserRepository), typeof(UserRepository));

            services.AddScoped(typeof(ICreateUserService), typeof(CreateUserService));
            services.AddScoped(typeof(IDeleteUserService), typeof(DeleteUserService));
            services.AddScoped(typeof(IGetAllUserService), typeof(GetAllUserService));
            services.AddScoped(typeof(IGetUserService), typeof(GetUserService));
            services.AddScoped(typeof(IUpdateEmailService), typeof(UpdateEmailService));

            services.AddSwaggerGen(c => c.SwaggerDoc("v1",
                new OpenApiInfo { Title = "Repository Pattern - Api", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Repository Pattern API V1");
            });
        }
    }
}
