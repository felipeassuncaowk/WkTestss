using Microsoft.AspNetCore.Mvc;
using WkCommerce.Application.Command.Category;
using WkCommerce.Application.Query.Category;
using WkCommerce.Core;
using WkCommerce.Core.Handlers;
using WkCommerce.Domain.Entity;
using WkCommerce.WebApi.Abstractions;

namespace WkCommerce.WebApi.Controllers;

public class CategoryController : ApiControllerBase
{
    public CategoryController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(PagedQuery<Category>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> Get(
        string name, 
        int index = Constants.DEFAULT_PAGGING_INDEX, 
        int size = Constants.DEFAULT_PAGGING_SIZE) =>
        ExecuteQueryAsync<CategoryGetPagedQuery, PagedResult<Category>>(new CategoryGetPagedQuery(name, index, size));
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Result<Category>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> GetById(int id) =>
        ExecuteQueryAsync<CategoryGetByIdQuery, Category>(new CategoryGetByIdQuery(id));
    
    [HttpPost]
    [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> Create(CategoryCreateCommand request) =>
        ExecuteCommandAsync<CategoryCreateCommand, int>(request);
    
    [HttpPut]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> Update(CategoryUpdateCommand request) =>
        ExecuteCommandAsync(request);
    
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> Delete( int id) =>
        ExecuteCommandAsync(new CategoryDeleteCommand(id));
}