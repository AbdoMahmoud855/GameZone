using Demo.BL.Interface;
using Demo.BL.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBussniesLogic(this IServiceCollection services) {
        
        services.AddScoped(typeof(IGamesRpo),typeof(GamesRepo));
services.AddScoped(typeof(IUnitOfWork),typeof(UnitOfWork));

        
        return services;
        }
    }
}
