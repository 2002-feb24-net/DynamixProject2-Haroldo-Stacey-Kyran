using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dynamix.API.Interfaces;
using Dynamix.API.Models;
using Dynamix.API.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Dynamix.WebAPI
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
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalAndAppServiceAngular", builder =>
                    builder.WithOrigins("http://localhost:4200", "https://dynamixhk.azurewebsites.net/ ")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            services.AddDbContext<DbDynamixContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbDynamix")));
            services.AddScoped<IUsersRepository, UserRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ILocationVisitorRepository, LocationVisitorRepository>();
            services.AddScoped<IEmojiRatingRepository, EmojiRatingRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Client API", Version = "v1" });
            });
            services.AddControllers();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowLocalAndAppServiceAngular");

            app.UseMvc();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Client API V1");
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();


            });

            
        }
    }
}
