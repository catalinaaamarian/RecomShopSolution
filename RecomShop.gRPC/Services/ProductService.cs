using Grpc.Core;

namespace RecomShop.gRPC.Services
{
    public class ProductServiceImpl : ProductService.ProductServiceBase
    {
        public override Task<ProductReply> GetProductPrice(ProductRequest request, ServerCallContext context)
        {
            // EXEMPLU – tu poți pune orice logică
            double price = request.ProductId switch
            {
                1 => 99.99,
                2 => 150.00,
                _ => 49.99
            };

            return Task.FromResult(new ProductReply
            {
                Price = price
            });
        }
    }
}
