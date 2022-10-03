using Contracts.Requests;
using Contracts.Services;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using ProtoBuf.Grpc.Client;

namespace Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddProduct()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7237");
            var client = channel.CreateGrpcService<IProductService>();

            var reply = await client.AddProductAsync(
                new AddProductRequest { Name = "From client" });
            
            return Ok(reply);
        }
    }
}
