using AwesomeGym.API.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AwesomeGym.API
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
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "AwesomeGym API", Version = "v1" }));

            //Conex�o com banco de dados
            var connectionStringSQLServer = Configuration.GetConnectionString("AwesomeGymSQLServer");
            var connectionStringMySQL = Configuration.GetConnectionString("AwesomeGymMySQL");
            
            //services.AddDbContext<AwesomeGymDbContext>(options => options.UseSqlServer(connectionStringSQLServer));

            //Banco de dados em mem�ria
            //services.AddDbContext<AwesomeGymDbContext>(options => options.UseInMemoryDatabase("AwesomeGymDb"));
            
            services.AddDbContext<AwesomeGymDbContext>(options => options.UseMySql(connectionStringMySQL));

            services.AddControllers();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AwesomeGym API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
