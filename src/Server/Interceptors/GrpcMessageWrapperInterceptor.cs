using Contracts.Base;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

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
        UnaryServerMethod<TRequest, TResponse> continuation) where TResponse : class
    {
        try
        {

            return await continuation(request, context);

        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);

            return FailedResponse<TResponse>(e.Message);
        }
    }

    private TResponse FailedResponse<TResponse>(string errorMessage) where TResponse : class
    {

        // var response = concreteResponse is IGrpcResponse;

        // var concreteResponse = response;


        var concreteResponse = Activator.CreateInstance<TResponse>();
        if (concreteResponse is IGrpcResponse response)
        {
            response.IsSuccess = false;
            response.ErrorMessage = errorMessage;
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        return concreteResponse;
    }
}