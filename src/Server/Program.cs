using ProtoBuf.Grpc.Server;
//using Server.Interceptors;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddCodeFirstGrpc();
    builder.Services.AddGrpc();
    //builder.Services.AddGrpc(c => c.Interceptors.Add<GrpcGlobalExceptionHandlerInterceptor>());
}


var app = builder.Build();
{
    app.MapGrpcService<ProductService>();
    app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

    app.Run();
}