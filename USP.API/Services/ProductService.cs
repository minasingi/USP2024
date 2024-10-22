namespace USP.API.Services;

public class ProductService : IProductService
{
    public async Task<string> Get() => "Mina";

    public async Task<string> Create() => "Created!";
}