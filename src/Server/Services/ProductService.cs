using Contracts.Base;
using Contracts.Requests;
using Contracts.Responses;
using ProtoBuf.Grpc;
using System.ServiceModel;
using Contracts.Models;

namespace Server.Services;

[ServiceContract(Name = "ProductService")]
public class ProductService : Contracts.Services.IProductService
{
    private readonly List<Category> _categories;
    private readonly AddProductReply _response;
    public ProductService()
    {
        _categories = new List<Category>
        {
            new() { Description = "Foods" },
            new() { Description = "Beverages" }
        };

        _response = new AddProductReply
        {
            Message = "Response from server",
            Categories = _categories
        };
    }

    public async Task<GrpcResponse<AddProductReply>> AddProductAsync(AddProductRequest request, CallContext context = default)
    {
        throw new Exception("Exception with type");

        return GrpcResponse<AddProductReply>.Ok(_response);
    }

    public async Task<GrpcResponse> GetProduct(AddProductRequest request, CallContext context)
    {
        throw new Exception("Exception with no type");

        return GrpcResponse.Ok();
    }
}