using System.ServiceModel;
using Contracts.Base;
using Contracts.Requests;
using ProtoBuf.Grpc;

namespace Contracts.Services.Client;

[ServiceContract(Name = "UserService")]
public interface IProductClientService
{
    [OperationContract]
    Task<GrpcResponseBase> GetProduct(AddProductRequest request, CallContext context = default);
}