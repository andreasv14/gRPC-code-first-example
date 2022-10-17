using Contracts.Requests;
using Contracts.Services;
using Contracts.Services.Client;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using ProtoBuf.Grpc.Client;

namespace Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductClientService _client;

        public ProductController()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7237");
            _client = channel.CreateGrpcService<IProductClientService>();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct()
        {
            var reply = await _client.AddProductAsync(
                new AddProductRequest { Name = "From client" });

            return Ok(reply);
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var reply = await _client.GetProduct(
                new AddProductRequest { Name = "From client" });

            return Ok(reply);
        }
    }
}
