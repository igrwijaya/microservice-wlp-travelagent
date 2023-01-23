using System.Reflection;
using Binus.ActivitiesVendor.Core.Application.Commons.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Binus.ActivitiesVendor.Core.Application
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