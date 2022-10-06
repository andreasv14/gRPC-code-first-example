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
        var concreteResponse = Activator.CreateInstance<TResponse>();
        if (concreteResponse is IGrpcResponseBase)
        {
            concreteResponse?.GetType().GetProperty("IsSuccess")?.SetValue(concreteResponse, false);
            concreteResponse?.GetType().GetProperty("ErrorMessage")?.SetValue(concreteResponse, errorMessage);
            concreteResponse?.GetType().GetProperty("StatusCode")?.SetValue(concreteResponse, (int)HttpStatusCode.InternalServerError);
            concreteResponse?.GetType().GetProperty("Data")?.SetValue(concreteResponse, null);

        }
        return concreteResponse;
    }
}