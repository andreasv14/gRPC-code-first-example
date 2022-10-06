using Contracts.Base;
using Contracts.Requests;
using Contracts.Responses;
using Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using ProtoBuf.Grpc;
using System.ServiceModel;

namespace Server.Services;

[ServiceContract]
public class ProductService : IProductService
{
    [CustomAttribute(typeof(GrpcResponse<AddProductRequest>))]
    public async Task<GrpcResponse<AddProductReply>> AddProductAsync(AddProductRequest request, CallContext context = default)
    {
        throw new Exception("dfdfgfdg");

        return GrpcResponse<AddProductReply>.Ok(new AddProductReply() { Message = "test response"});
    }

    public async Task<GrpcResponseBase> GetProduct(AddProductRequest request, CallContext context)
    {
        throw new Exception("dfdfgfdg");
        return GrpcResponseBase.Ok();
    }

    //public async Task<BaseResponse<AddProductReply>> AddProductAsync(AddProductRequest request, CallContext context = default)
    //{
    //    //throw new Exception("dfdfgfdg");

    //    var d = new AddProductReply
    //    {
    //        Message = "From server are you sure"
    //    };

    //    return new BaseResponse<AddProductReply>
    //    {
    //        Data = d
    //    };
    //}
}