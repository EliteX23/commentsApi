using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using commentsApi.middlewares;
using commentsApi.MongoConnection;
using Data;
using Data.Repositories;
using Data.Services;
using Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.Interfaces;

namespace commentsApi
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
            var mongoConectionString = Configuration.GetSection(nameof(CommentDatabaseSettings)).Get<Dictionary<string, string>>();
            services.AddSingleton<ITokenRepository, SecurityRepository>(serviceProvider =>
                 {
                     return new SecurityRepository(mongoConectionString);
                 })
                .AddSingleton<IToken, SecurityService>();

            
            services.AddSingleton<ICommentDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<CommentDatabaseSettings>>().Value)
                .AddScoped<ICommentRepository, CommentRepository>(serviceProvider =>
                {
                    return new CommentRepository(mongoConectionString);
                })
                .AddScoped<IComment, CommentService>()
                 .AddScoped<ICSVService, CSVService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<TokenMiddleware>();
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
