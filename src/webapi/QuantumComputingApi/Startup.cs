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
using QuantumComputingApi.Dtos.Producer;
using QuantumComputingApi.Dtos.Producer.Impl;
using QuantumComputingApi.Utils;
using QuantumComputingApi.Services;
using QuantumComputingApi.Services.Impl;
using QuantumComputingApi.Utils.Impl;


using QuantumComputingApi.Dtos.Impl;
using QuantumComputingApi.Dtos;

namespace QuantumComputingApi
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
            services.AddTransient<IProvider, Provider>();

            services.AddSingleton<ICirquitService, CirquitServiceImpl>();

            
            services.AddMvc( options => {
                options.InputFormatters.Insert(0, services.BuildServiceProvider().GetRequiredService<IProvider>().ProvideProducer().ProduceTextInputFormatter());
                options.OutputFormatters.Insert(0,services.BuildServiceProvider().GetRequiredService<IProvider>().ProvideProducer().ProduceTextOutputFormatter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
