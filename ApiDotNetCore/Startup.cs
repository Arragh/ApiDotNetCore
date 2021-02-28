using ApiDotNetCore.Models.ContextModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VueCliMiddleware;

namespace ApiDotNetCore
{
    public class Startup
    {
        IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(); // ����� ��� ����������� api-�������� � ������ �������
            services.AddControllers();
            services.AddDbContext<UsersContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ApiDotNetCoreDB")));
            services.AddTransient<IUsersRepository, EFUsersRepository>();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseDefaultFiles();
            //app.UseStaticFiles();
            app.UseRouting();
            app.UseSpaStaticFiles();
            //app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()); // ����� ��� ����������� api-�������� � ������ �������

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                {
                    spa.Options.SourcePath = "ClientApp/";
                    spa.UseVueCli(npmScript: "serve");
                }
                else
                {
                    spa.Options.SourcePath = "dist";
                }
            });
        }
    }
}
