using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
//After setting uo Context class add imports
using Microsoft.EntityFrameworkCore;
using Brushless.Data;
namespace Brushless
{
    public class Startup
    {
        private  IServiceCollection _services;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _services = services;
            _services.AddCors();
            /*
            services.AddCors(options =>  
            {  
                options.AddPolicy("Policy11",  
                builder => builder.WithOrigins("http://localhost:4200"));  
            });*/ 
            _services.AddControllers();
             _services.AddRazorPages();

            _services.AddDbContext<RazorDropContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SQLVerbindung")));
      }

        // This method 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
          
            app.UseHttpsRedirection();
            app.UseRouting();
            
            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
            //app.UseCors("AllowMyOrigin");
            
            app.UseAuthentication(); //too?
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
