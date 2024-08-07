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
    /// <param name="description"></param>
    /// <param name="price"></param>
    private Product(string name, string description, decimal price)
        : base(Guid.NewGuid())
    {
        Name = name;
        Description = description;
        Price = price;
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
    public string Description { get; private set; } = default!;


    /// <summary>
    /// 
    /// </summary>
    public decimal Price { get; private set; } = default!;

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
        Product product = new(name, description, price);

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
    public void Update(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;

        RaiseDomainEvent(new ProductUpdatedDomainEvent(this));
    }
}
