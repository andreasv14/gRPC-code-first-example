using System.ServiceModel;
using Contracts.Base;
using Contracts.Requests;
using Contracts.Responses;
using ProtoBuf.Grpc;

namespace Contracts.Services;

[ServiceContract]
public interface IProductService
{
    [OperationContract]
    Task<BaseResponse<AddProductReply>> AddProductAsync(AddProductRequest request, CallContext context = default);
    
//    [OperationContract]
//    Task<BaseResponse> AddProductAsync(AddProductRequest request, CallContext context = default);
}