using Contracts.Base;
using Contracts.Requests;
using Contracts.Responses;
using Contracts.Services;
using ProtoBuf.Grpc;

namespace Server.Services;

public class ProductService : IProductService
{
    public async Task<BaseResponse<AddProductReply>> AddProductAsync(AddProductRequest request, CallContext context = default)
    {
        return new BaseResponse<AddProductReply>
        {
            IsSuccess = true,
            Data = new AddProductReply
            {
                Message = "From server are you sure"
            }
        };
    }
}