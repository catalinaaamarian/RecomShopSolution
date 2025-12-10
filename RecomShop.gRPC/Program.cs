using RecomShop.gRPC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<ProductServiceImpl>();
app.MapGet("/", () => "gRPC server is running");

app.Run();
