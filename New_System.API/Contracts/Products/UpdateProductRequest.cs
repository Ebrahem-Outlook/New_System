namespace New_System.API.Contracts.Products;

public sealed record UpdateProductRequest(Guid ProductId, string Name, string Description, decimal Price);
