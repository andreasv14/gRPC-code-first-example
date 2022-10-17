using System.ServiceModel;
using Contracts.Base;
using Contracts.Requests;
using Contracts.Responses;
using ProtoBuf.Grpc;

namespace Contracts.Services.Client;

[ServiceContract(Name = "UserService")]
public interface IProductClientService
{
    [OperationContract]
    Task<GrpcResponse> GetProduct(AddProductRequest request, CallContext context = default);

    [OperationContract]
    Task<GrpcResponse<AddProductReply>> AddProductAsync(AddProductRequest request, CallContext context = default);
}