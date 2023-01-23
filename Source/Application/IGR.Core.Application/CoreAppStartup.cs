using System.Reflection;
using FluentValidation;
using IGR.Core.Application.Commons.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IGR.Core.Application
{
    public static class CoreAppStartup
    {
        public static void AddCoreApp(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        }
    }
}