<<<<<<< HEAD
﻿using BusinessLogic.Core;
using BusinessLogic.Logging;
using DbComm.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;

=======
﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
>>>>>>> 4077e494a1c9985f068e6f701635159e7cfe96ff

namespace UsersApi
{
    public class Startup
    {
<<<<<<< HEAD
        public static Container Container { get; private set; } = new Container();

=======
>>>>>>> 4077e494a1c9985f068e6f701635159e7cfe96ff
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
<<<<<<< HEAD


            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(Container));
            services.AddSimpleInjector(Container, options =>
                options.AddAspNetCore()
                    .AddControllerActivation());
            services.UseSimpleInjectorAspNetRequestScoping(Container);
=======
>>>>>>> 4077e494a1c9985f068e6f701635159e7cfe96ff
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
<<<<<<< HEAD

            app.UseSimpleInjector(Container);
            Container.Register<ILogger, FileLogger>();
            Container.Register<IDataProcessor, DataProcessor>();
            Container.Register<IUserDbAccessLayer, UserDbMongo>(); // TODO: what if I don't have a reference to the Db project? Can I register dependencies for it?
            
            Container.Verify();
=======
>>>>>>> 4077e494a1c9985f068e6f701635159e7cfe96ff
        }
    }
}
