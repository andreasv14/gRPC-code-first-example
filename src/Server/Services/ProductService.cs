using Contracts.Base;
using Contracts.Requests;
using Contracts.Responses;
using ProtoBuf.Grpc;
using System.ServiceModel;

namespace Server.Services;

[ServiceContract(Name = "ProductService")]
public class ProductService : Contracts.Services.IProductService
{
    public async Task<GrpcResponse<AddProductReply>> AddProductAsync(AddProductRequest request, CallContext context = default)
    {
        return GrpcResponse<AddProductReply>.Ok(new AddProductReply() { Message = "test response"});
    }

    public async Task<GrpcResponseBase> GetProduct(AddProductRequest request, CallContext context)
    {
        return GrpcResponseBase.Ok();
    }
}