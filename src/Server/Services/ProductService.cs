using Contracts.Base;
using Contracts.Requests;
using Contracts.Responses;
using Contracts.Services;
using ProtoBuf.Grpc;

namespace Server.Services;

public class ProductService : IProductService
{
    public async Task<AddProductReply> AddProductAsync(AddProductRequest request, CallContext context = default)
    {
        throw new Exception("Domain exception");

        return new AddProductReply
        {
            Message = "From server"
        };
    }
}