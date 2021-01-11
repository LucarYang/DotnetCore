using DreamSky_Template1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamSky_Template1
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //服务引用层
            //services.AddMvc();//引用mvc
            //mvc core 只包含了核心的MVC
            //而MVC中 包含了核心的MVC 以及其他的第三方常用的服务和方法
            services.AddMvcCore();

            services.AddSingleton<IStudentInterface, MockStudentInterFace>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILogger<Startup> logger)
        {
            //服务应用层

            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions();
                developerExceptionPageOptions.SourceCodeLineCount = 10; //一样显示行数
                app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            } else if (env.IsStaging()||env.IsEnvironment("UAT")||env.IsProduction()) {
                app.UseExceptionHandler("/Error");
            }

            ////中间件
            //app.Use(async (context, next) =>
            //{
            //    context.Response.ContentType = "text/plain;charset=utf-8";
            //    logger.LogInformation("M1:传入请求");
            //    //await context.Response.WriteAsync(" this is first hello world ");
            //    await next();
            //    logger.LogInformation("M1:传出响应");
            //});
            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("M2:传入请求");
            //    await next();
            //    logger.LogInformation("M2:传出响应");
            //});

            //app.Run(async (context) =>
            //{
            //    //获取进程名
            //    //var ProcessName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            //    //appSetting
            //    //var configValue = _configuration["Mykey"];
            //   //await context.Response.WriteAsync("this is second hello world");
            //    await context.Response.WriteAsync("M3:处理请求 并生成响应");
            //    logger.LogInformation("M3:处理请求 并生成响应");




            //// 添加默认指定文件
            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("index_Dream.html");

            ////添加默认文件中间件 index.html index.htm defaul.html defaul.htm
            ////app.UseDefaultFiles();
            //app.UseDefaultFiles(defaultFilesOptions);

            ////添加静态文件中间件
            //app.UseStaticFiles();

            //以上静态文件的统一概括
            //FileServerOptions fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("index_Dream.html");

            //app.UseFileServer(fileServerOptions);

            //app.Run(async (context) =>
            //{

            //    await context.Response.WriteAsync("M3:处理请求 并生成响应");
            //    //logger.LogInformation("M3:处理请求 并生成响应");
            //});


            app.UseMvcWithDefaultRoute();
            
            app.Run(async (context) =>
            {
                //异常处理
                //throw new Exception("程序异常 请查看");
                //await context.Response.WriteAsync("Hello World");

                await context.Response.WriteAsync("Hosting Environame:" + env.EnvironmentName);
            });

        }
    }
}
