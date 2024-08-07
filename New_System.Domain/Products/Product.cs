using New_System.Domain.Core.BaseType;
using New_System.Domain.Products.Events;

namespace New_System.Domain.Products;

/// <summary>
/// 
/// </summary>
public sealed class Product : AggregateRoot
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="price"></param>
    /// <param name="description"></param>
    private Product(string name, decimal price, string description)
        : base(Guid.NewGuid())
    {
        Name = name;
        Price = price;
        Description = description;
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// 
    /// </summary>
    private Product() : base() { }

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; private set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public decimal Price { get; private set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public string Description { get; private set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public DateTime CreatedAt { get; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime? UpdatedAt { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="price"></param>
    /// <param name="description"></param>
    /// <param name="items"></param>
    /// <returns></returns>
    public static Product Create(string name, decimal price, string description)
    {
        Product product = new(name, price, description);

        product.RaiseDomainEvent(new ProductCreatedDomainEvent(product));

        return product;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="price"></param>
    /// <param name="description"></param>
    /// <param name="items"></param>
    public void Update(string name, decimal price, string description)
    {
        Name = name;
        Price = price;
        Description = description;

        RaiseDomainEvent(new ProductUpdatedDomainEvent(this));
    }
}
