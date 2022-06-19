using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Core.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        public string ApiName { get; set; } = "TaskManager.Core";
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var basePath = AppContext.BaseDirectory;

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "V1",
                    Title = $"{ApiName} 接口文档——Netcore 3.1",
                    Description = $"{ApiName} HTTP API V1",
                });
                c.OrderActionsBy(o => o.RelativePath);

                //var xmlPath = UsePathBaseExtensions.Combine(basePath, "Task.Core.API.xml");
                c.IncludeXmlComments("D:\\yze\\bachelor\\third\\courses\\Next\\.Net\\期末\\Task.Core\\Task.Core.API\\Task.Core.API.xml", true);

                c.IncludeXmlComments("D:\\yze\\bachelor\\third\\courses\\Next\\.Net\\期末\\Task.Core\\Task.Core.Model\\Task.Core.Model.xml");
            });

            //数据库配置
            TaskManager.Core.Repository.sugar.BaseDBConfig.ConnectionString = Configuration.GetSection("AppSettings:MysqlConnection").Value;

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/V1/swagger.json", $"{ApiName} V1");

                //原来的访问地址localhost:5000/swagger，如果想在根域名（localhost:5000）访问该文件，可以配置下面代码
                //路径配置为空，表示直接在根域名（localhost:5000）访问该文件,然后在launchSettings.json文件把launchUrl去掉，如果你想换一个路径，直接写名字即可，比如直接写c.RoutePrefix = "doc";
                c.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
