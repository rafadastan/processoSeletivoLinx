using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetoLinx.Application.Contracts;
using ProjetoLinx.Application.Services;
using ProjetoLinx.Domain.Contracts.Repositories;
using ProjetoLinx.Domain.Contracts.Services;
using ProjetoLinx.Domain.Services;
using ProjetoLinx.Infra.Context;
using ProjetoLinx.Infra.Repositories;
using SUC.Domain.Notifications;

namespace ProjetoLinx.IOC
{
    public static class AddDependencyInjections
    {
        public static IServiceCollection AddDependencyInjection(
            this IServiceCollection services)
        {
            //Application
            services.AddTransient<ICustomerApplicationService, CustomerApplicationService>();
            services.AddTransient<IAddressApplicationService, AddressApplicationService>();

            //Domain

            services.AddTransient<ICustomerDomainService, CustomerDomainService>();
            services.AddTransient<IAddressDomainService, AddressDomainService>();

            //Repository
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //CrossCutting

            services.AddScoped<NotificationContext>();


            services.AddTransient<SqlContext>();

            return services;
        }
    }
}
