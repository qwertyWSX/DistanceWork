using DistanceWork.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.FileProviders;


namespace DistanceWork
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        string connection;

        public void ConfigureServices(IServiceCollection services)
        {
         
            connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DistanceWorkContext>(options => options.UseSqlServer(connection));
            services.AddScoped<DistanceWorkContext>();
            services.AddControllers().AddNewtonsoftJson();
            services.AddCors(options =>
        {          
            options.AddPolicy("MyPolicy",
                policy =>
                {
                    policy.WithOrigins("http://localhost:3000")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowAnyOrigin();
                });
        });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
               app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();


            app.UseRouting();

            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
               endpoints.MapControllers();  
            });
        }
    }
}
