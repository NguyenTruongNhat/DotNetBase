using Asp.Versioning;
using INuBase.Contract.Services.V2.Product;
using INuBase.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INuBase.Presentation.Controllers.V2;
[ApiVersion(2)]
public class ProductsController : ApiController
{
    public ProductsController(ISender sender) : base(sender)
    {
    }

    [HttpPost(Name = "CreateProducts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Products([FromBody] Command.CreateProductCommand createProduct)
    {
        var result = await Sender.Send(createProduct);
        if (result.IsFailure)
            return HandlerFailure(result);

        return Ok(result);
    }
}
