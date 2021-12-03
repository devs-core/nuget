using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Andreani.ARQ.Core.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //Request
            var jsonOptions = new JsonSerializerOptions
            {
                MaxDepth = 0,
            };
            var json = JsonSerializer.Serialize(request, jsonOptions);
            _logger.LogInformation("Handling Request: {name} with params: {json}", typeof(TRequest).Name, json);
            var response = await next();
            //Response
            json = JsonSerializer.Serialize(response, jsonOptions);
            _logger.LogInformation("Response Request: {name} with Content: {json}", typeof(TRequest).Name, json);
            return response;
        }
    }
}
