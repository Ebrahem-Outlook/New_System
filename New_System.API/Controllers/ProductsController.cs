using MediatR;
using Microsoft.AspNetCore.Mvc;
using New_System.API.Contracts.Products;
using New_System.Application.Products.Commands.CreateProduct;
using New_System.Application.Products.Commands.DeleteProduct;
using New_System.Application.Products.Commands.UpdateProduct;
using New_System.Application.Products.Queries.GetAll;
using New_System.Application.Products.Queries.GetById;
using New_System.Application.Products.Queries.GetByName;

namespace New_System.API.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public sealed class ProductsController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest request) =>
        Ok(await sender.Send(
            new CreateProductCommand(
                request.Name,
                request.Description,
                request.Price)));

    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductRequest request) =>
        Ok(await sender.Send(
            new UpdateProductCommand(
                request.ProductId,
                request.Name,
                request.Description,
                request.Price)));

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id) => Ok(await sender.Send(new DeleteProductCommand(id)));

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await sender.Send(new GetAllProductsQuery()));

    [HttpGet("id")]
    public async Task<IActionResult> GetById(Guid id) => Ok(await sender.Send(new GetProductByIdQuery(id)));

    [HttpGet("name")]
    public async Task<IActionResult> GetByName(string name) => Ok(await sender.Send(new GetProductByNameQuery(name)));
}
