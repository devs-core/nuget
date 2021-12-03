using Andreani.ARQ.Core.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Andreani.ARQ.Pipeline.Extension
{
    public static class PipelineExtension
    {

        public static IServiceCollection AddAndreaniPipeline(this IServiceCollection services)
        {

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

            return services;
        }
    }
}
