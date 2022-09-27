using Grpc.Core;
using Grpc.Core.Interceptors;

namespace Server.Interceptors;

public class GrpcGlobalExceptionHandlerInterceptor : Interceptor
{
    private readonly ILogger<GrpcGlobalExceptionHandlerInterceptor> _logger;

    public GrpcGlobalExceptionHandlerInterceptor(ILogger<GrpcGlobalExceptionHandlerInterceptor> logger)
    {
        _logger = logger;
    }

    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await base.UnaryServerHandler(request, context, continuation);
        }
        catch (DomainException de)
        {
            var responseVm = new ResponseViewModel
            {
                Code = de.Code,
                Message = de.Message
            };

            return MapResponse<TRequest, TResponse>(responseVm);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);

            var responseVm = new ResponseViewModel
            {
                Code = "99999",
                Message = "Server error"
            };

            return MapResponse<TRequest, TResponse>(responseVm);
        }
    }

    private TResponse MapResponse<TRequest, TResponse>(ResponseViewModel responseViewModel)
    {
        var concreteResponse = Activator.CreateInstance<TResponse>();

        concreteResponse?.GetType().GetProperty(nameof(responseViewModel.Code))?.SetValue(concreteResponse, responseViewModel.Code);

        concreteResponse?.GetType().GetProperty(nameof(responseViewModel.Message))?.SetValue(concreteResponse, responseViewModel.Message);

        return concreteResponse;
    }
}

public class ResponseViewModel
{
    public string Code { get; set; }

    public string Message { get; set; }
}

public class DomainException : Exception
{
    public string Code { get; set; }

    public string Message { get; set; }

    public DomainException(string code, string message)
    {
        Code = code;
        Message = message;
    }
}