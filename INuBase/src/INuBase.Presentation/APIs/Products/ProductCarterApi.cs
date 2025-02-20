using Carter;
using INuBase.Contract.Abstractions.Shared;
using INuBase.Contract.Services.V1.Product;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace INuBase.Presentation.APIs.Products;
public class ProductCarterApi : ICarterModule
{
    private const string BaseUrl = "/api/carter/v{version:apiVersion}/products";

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group1 = app.NewVersionedApi("products-cater-name-show-on-swagger")
                        .MapGroup(BaseUrl).HasApiVersion(1);
        group1.MapPost(string.Empty, CreateProductsV1);


        var group2 = app.NewVersionedApi("products-cater-name-show-on-swagger")
            .MapGroup(BaseUrl).HasApiVersion(2);

        group2.MapPost(string.Empty, CreateProductsV2);
    }

    public static async Task<IResult> CreateProductsV1(ISender sender, [FromBody] Command.CreateProductCommand createProduct)
    {
        var result = await sender.Send(createProduct);
        if (result.IsFailure)
        {
            return HandlerFailure(result);
        }
        return Results.Ok(result);
    }

    public static async Task<IResult> CreateProductsV2(ISender sender, [FromBody] Command.CreateProductCommand createProduct)
    {
        var result = await sender.Send(createProduct);
        if (result.IsFailure)
        {
            return HandlerFailure(result);
        }
        return Results.Ok(result);
    }

    private static IResult HandlerFailure(Result result) =>
        result switch
        {
            { IsSuccess: true } => throw new InvalidOperationException(),
            IValidationResult validationResult =>
                Results.BadRequest(
                    CreateProblemDetails(
                        "Validation Error", StatusCodes.Status400BadRequest,
                        result.Error,
                        validationResult.Errors)),
            _ =>
                Results.BadRequest(
                    CreateProblemDetails(
                        "Bab Request", StatusCodes.Status400BadRequest,
                        result.Error))
        };

    private static ProblemDetails CreateProblemDetails(
        string title,
        int status,
        Error error,
        Error[]? errors = null) =>
        new()
        {
            Title = title,
            Type = error.Code,
            Detail = error.Message,
            Status = status,
            Extensions = { { nameof(errors), errors } }
        };
}
