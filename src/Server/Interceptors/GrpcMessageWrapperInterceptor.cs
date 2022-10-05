using Contracts.Base;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace Server.Interceptors;

public class GrpcMessageWrapperInterceptor : Interceptor
{
    private readonly ILogger<GrpcMessageWrapperInterceptor> _logger;

    public GrpcMessageWrapperInterceptor(ILogger<GrpcMessageWrapperInterceptor> logger)
    {
        _logger = logger;
    }

    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            var call = continuation(request, context);

            var response = new BaseResponse<TResponse>()
            {
                IsSuccess = true,
                Data = call.Result
            };

            return MapResponse(response);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);

            var response = new BaseResponse<TResponse>()
            {
                IsSuccess = false,
                ErrorMessage = e.Message
            };

            return MapResponse(response);
        }
    }

    private TResponse MapResponse<TResponse>(BaseResponse<TResponse> response) where TResponse : class
    {
        var concreteResponse = Activator.CreateInstance<TResponse>();
        concreteResponse?.GetType().GetProperty(nameof(response.IsSuccess))?.SetValue(concreteResponse, response.IsSuccess);
        concreteResponse?.GetType().GetProperty(nameof(response.ErrorMessage))?.SetValue(concreteResponse, response.ErrorMessage);
        concreteResponse?.GetType().GetProperty(nameof(response.Data))?.SetValue(concreteResponse, response.Data);

        return concreteResponse;
    }
}