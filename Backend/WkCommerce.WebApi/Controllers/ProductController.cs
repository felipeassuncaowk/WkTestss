using Microsoft.AspNetCore.Mvc;
using WkCommerce.Application.Command.Product;
using WkCommerce.Application.Query.Product;
using WkCommerce.Core;
using WkCommerce.Core.Handlers;
using WkCommerce.Domain.Entity;
using WkCommerce.WebApi.Abstractions;

namespace WkCommerce.WebApi.Controllers;

public class ProductController : ApiControllerBase
{
    public ProductController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(PagedQuery<Product>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> Get(
        string name, 
        bool? fgActive, 
        int index = Constants.DEFAULT_PAGGING_INDEX, 
        int size = Constants.DEFAULT_PAGGING_SIZE) =>
        ExecuteQueryAsync<ProductGetPagedQuery, PagedResult<Product>>(new ProductGetPagedQuery(name, fgActive, index, size));
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Result<Product>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> GetById(int id) =>
        ExecuteQueryAsync<ProductGetByIdQuery, Product>(new ProductGetByIdQuery(id));
    
    [HttpPost]
    [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> Create(ProductCreateCommand request) =>
        ExecuteCommandAsync<ProductCreateCommand, int>(request);
    
    [HttpPut]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> Update(ProductUpdateCommand request) =>
        ExecuteCommandAsync(request);
    
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> Delete(int id) =>
        ExecuteCommandAsync(new ProductDeleteCommand(id));
}