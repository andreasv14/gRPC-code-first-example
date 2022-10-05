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
    [CustomAttribute(typeof(BaseResponse<AddProductRequest>))]
    public async Task<AddProductReply> AddProductAsync(AddProductRequest request, CallContext context = default)
    {
        //throw new Exception("dfdfgfdg");

        return new AddProductReply
        {
            Message = "From server are you sure"
        };
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