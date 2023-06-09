using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services;
        }
    }
}