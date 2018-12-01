using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FirstMediatR.Data;
using FirstMediatR.Data.Interfaces;
using FirstMediatR.Services;
using FirstMediatR.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FirstMediatR
{
    public class Startup
    {
        public IContainer ApplicationContainer {get; private set;}
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<InMemoryUserRepository>().As<IUserRepository>();
            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IApplicationLifetime appLifeTime)
        {
            app.UseHttpsRedirection();
            app.UseMvc();
            appLifeTime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
