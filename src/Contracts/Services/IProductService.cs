using System.ServiceModel;
using Contracts.Requests;
using Contracts.Responses;
using ProtoBuf.Grpc;

namespace Contracts.Services;

[ServiceContract]
public interface IProductService
{
    [OperationContract]
    Task<AddProductReply> AddProductAsync(AddProductRequest request, CallContext context = default);
}