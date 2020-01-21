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
using QuantumComputingApi.Dtos;
using QuantumComputingApi.Dtos.Impl;
using QuantumComputingApi.Dtos.Producer;
using QuantumComputingApi.Dtos.Producer.Impl;
using QuantumComputingApi.Formatters;
using QuantumComputingApi.Properties;
using QuantumComputingApi.Services;
using QuantumComputingApi.Services.Impl;
using QuantumComputingApi.Utils;
using QuantumComputingApi.Repositories;
using QuantumComputingApi.Repositories.Impl;

namespace QuantumComputingApi {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.Configure<DatabaseSettings> (Configuration.GetSection(nameof(DatabaseSettings)));
            
            // services.AddTransient<IProvider>(sp =>
            //     new Provider(DtoType.SnakeCase));

            services.AddSingleton<DtoProducerBase, SnakeCaseDtoProducer>();

            services.AddSingleton<ICircuitService, CircuitService>();
            services.AddSingleton<ICircuitRepository, CircuitRepository>();
            
            services.AddTransient<Mapper>(sp =>
                new Mapper(
                    sp.GetRequiredService<DtoProducerBase>()
                ));
            
            
            services.AddControllers();
            services.AddMvc();

            services.AddMvc(options => {
                var prod = services.BuildServiceProvider().GetRequiredService<DtoProducerBase>();
                options.InputFormatters.Insert(0, new DtoInputFormatter(prod.ProduceDeserializer()));
                options.OutputFormatters.Insert(0, new DtoOutputFormatter(prod.ProduceSerializer()));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}