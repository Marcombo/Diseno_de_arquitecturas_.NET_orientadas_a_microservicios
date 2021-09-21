using System;
using System.Reflection;
using System.Text;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ms.attendances.api.Consumers;
using ms.attendances.api.Mappers;
using ms.attendances.application.Commands;
using ms.attendances.application.Mappers;
using ms.attendances.domain.Repositories;
using ms.attendances.infrastructure.Data;
using ms.attendances.infrastructure.Mappers;
using ms.attendances.infrastructure.Repositories;
using ms.rabbitmq.Consumers;
using ms.rabbitmq.Middlewares;

namespace ms.attendances.api
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

            services.AddScoped(typeof(IAttendanceContext), typeof(AttendanceMongoContext));
            services.AddTransient(typeof(IAttendanceContext), typeof(AttendanceMongoContext));
            services.AddScoped(typeof(IAttendanceRepository), typeof(AttendanceRepository));
            services.AddTransient(typeof(IAttendanceRepository), typeof(AttendanceRepository));

            var automapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddMaps(typeof(AttendanceProfile).Assembly);
                mapperConfig.AddMaps(typeof(AttendanceMongoProfile).Assembly);
                mapperConfig.AddProfile(typeof(EventMapperProfile));
            });
            IMapper mapper = automapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            
            services.AddMediatR(typeof(CreateAttendanceCommand).GetTypeInfo().Assembly);

            services.AddSingleton(typeof(IConsumer), typeof(AttendancesConsumer));

            var privateKey = Configuration.GetValue<string>("Authentication:JWT:Key");

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey)),
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero

                };
            });

            services.AddSwaggerGen(swagger => {
                swagger.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                { Title = "Historical Attendance Api", Version = "v1" });
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Cabecera de autorización JWT. \r\n Introduzca ['Bearer'] [espacio] [Token].",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme
                                                            , Id = "Bearer" }
                        },new string[] {}
                }});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IConsumer consumer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseRabbitConsumer(consumer);

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json"
                , "Historical Attendance API V1"));
        }
    }
}
