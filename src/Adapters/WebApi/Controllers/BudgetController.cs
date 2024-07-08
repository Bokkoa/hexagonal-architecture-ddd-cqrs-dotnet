using Application.Abstractions.Ports.Handlers;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BudgetController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> RegisterAsync(
         [FromServices] ICommandHandler<Command.RegisterBudgetCommand> handler,
        [FromBody] Command.RegisterBudgetCommand command,
        CancellationToken cancellationToken)
    {
        try
        {
            await handler.Handle(command, cancellationToken);

            return Ok();
        }catch(Exception ex)
        {
            return BadRequest(ex);
        }
    }
    
    [HttpPost("category")]
    public async Task<IActionResult> AddCategory(
         [FromServices] ICommandHandler<Command.AddCategoryCommand> handler,
        [FromBody] Command.AddCategoryCommand command,
        CancellationToken cancellationToken)
    {
        try
        {
            await handler.Handle(command, cancellationToken);

            return Ok();
        }catch(Exception ex)
        {
            return BadRequest(ex);
        }
    }    
    
    [HttpGet("category/{accountId}")]
    public async Task<IActionResult> ListCategoryAsync(
         [FromServices] IQueryHandler<Query.ListCategoryQuery, List<ViewModel.CategoryViewModel>> handler,
         [FromRoute] Guid accountId,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await handler.Handle(new Query.ListCategoryQuery(accountId), cancellationToken);

            return Ok(result);
        }catch(Exception ex)
        {
            return BadRequest(ex);
        }
    }
}
