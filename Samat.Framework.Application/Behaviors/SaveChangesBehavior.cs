using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Samat.Framework.Domain;

namespace Samat.Framework.Application.Behaviors;
public class SaveChangesBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<SaveChangesBehavior<TRequest, TResponse>> _logger;
    private readonly IServiceProvider _serviceProvider;

    public SaveChangesBehavior(ILogger<SaveChangesBehavior<TRequest, TResponse>> logger,
        IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();

        var saveChangesBehavior = request as ISaveChangesBehavior;

        if (saveChangesBehavior != null && saveChangesBehavior.DisableSaveChangeOnCommandHandler())
        {
            return response;
        }

        if (request.GetType().Name.Contains("command", StringComparison.InvariantCultureIgnoreCase))
        {
            _logger.LogInformation("SaveChangesBehavior: Before UnitOfWork.SaveChangesAsync()");

            var _unitOfWork = _serviceProvider.GetRequiredService<IUnitOfWork>();

            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("SaveChangesBehavior: After UnitOfWork.SaveChangesAsync()");
        }

        return response;
    }
}
