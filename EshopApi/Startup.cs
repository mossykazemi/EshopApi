using System.IO;
using EshopApi.Contracts;
using EshopApi.Models;
using EshopApi.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

namespace EshopApi
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

            //Connection String
            services.AddDbContext<EshopApi_DBContext>(options =>
            {
                options.UseSqlServer("Data Source=MOSSY;Initial Catalog=EshopApi_DB;Integrated Security=true;");
            });
            //IOC
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            //Cache
            services.AddResponseCaching();
            services.AddMemoryCache();
            //JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "http://localhost:21747",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("VerifyMostafaSampleToken"))
                    };
                });

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCors", builder =>
                {
                    builder
                        .SetIsOriginAllowed(hostname => true)
                        //.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .Build();

                });
            });

            //Swagger
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1",new OpenApiInfo
                {
                    Title = "My First Swagger"
                });
                //swagger.IncludeXmlComments(Path.Combine(Directory.GetCurrentDirectory(),@"EshopApi\EshopApi\EshopApi.xml"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseCors("EnableCors");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","My First Swagger");
            });
            app.UseResponseCaching();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
