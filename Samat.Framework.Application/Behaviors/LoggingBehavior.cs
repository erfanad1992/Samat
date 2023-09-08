using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Samat.Framework.Application.Behaviors;
public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        TResponse response;
        _logger.LogInformation("Handling request {Request}", request);

        try
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();

            response = await next();

            stopwatch.Stop();

            if (stopwatch.ElapsedMilliseconds > TimeSpan.FromSeconds(5).TotalMilliseconds)
            {
                // This method has taken a long time, So we log that to check it later.
                _logger.LogWarning("{Request} has taken {ElapsedMilliseconds} to run completely!", request, stopwatch.ElapsedMilliseconds);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Unhandled Exception in MediatR", ex);

            throw;
        }
        _logger.LogInformation("Handled - response: {Response}", response);

        return response;
    }

}