using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using SEP.Framework.Seedwork.Identity;
using SEP.Framework.Seedwork.Identity.Manager;
using SEP.Framework.Seedwork.Repository;
using SEP.Framework.Seedwork.Repository.Core;
using SEP.Framework.Seedwork.DbInitialize;
using SEP.Framework.Seedwork.ServiceContracts;
using SEP.Framework.DAO.Context;
using SEP.Framework.DAO.Identity.UserStore;
using SEP.Framework.DAO.Mapping.Configuration;
using SEP.Framework.DAO.DbInitialize;
using SEP.Framework.AppService.Services;

namespace SEP.Framework.AppService.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SepDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultDb"))
                    .UseLazyLoadingProxies();
            });

            // Identity configuration
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<SepDbContext>()
                .AddUserStore<DLUserStore>()
                .AddRoleStore<DLRoleStore>()
                .AddUserManager<DLUserManager>()
                .AddSignInManager<DLSignInManager>()
                .AddRoleManager<DLRoleManager>()
                .AddDefaultTokenProviders();

            Mapper.Initialize(x =>
            {
                x.AddProfile<MappingConfiguration>();
            });
            services.AddAutoMapper();

            return services;
        }

        public static IServiceCollection InjectDependency(this IServiceCollection services)
        {
            services.AddScoped(typeof(DbContext), typeof(SepDbContext));
            services.AddTransient(typeof(IHttpContextAccessor), typeof(HttpContextAccessor));
            services.AddTransient(typeof(IDbInitializer), typeof(DbInitializer));
            services.AddTransient(typeof(IEmailSender), typeof(EmailSender));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,,>));

            services.ConfigureServicesDI();

            return services;
        }

        private static void ConfigureServicesDI(this IServiceCollection services)
        {
            //Configure DI for services
            services.Scan(scan =>
            {
                scan.FromAssemblies(Assembly.GetExecutingAssembly())
                    .AddClasses(classes => classes.AssignableTo<IService>())
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
            });
        }
    }
}
