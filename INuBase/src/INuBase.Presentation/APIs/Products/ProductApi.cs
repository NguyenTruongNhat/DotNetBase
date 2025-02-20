using Asp.Versioning.Builder;
using INuBase.Contract.Abstractions.Shared;
using INuBase.Contract.Services.V1.Product;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INuBase.Presentation.APIs.Products;
public static class ProductApi
{
    private const string BaseUrl = "/api/minimal/v{version:apiVersion}/products";

    public static IVersionedEndpointRouteBuilder MapProductApiV1(this IVersionedEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup(BaseUrl).HasApiVersion(1);
        group.MapPost(string.Empty, CreateProducts);

        return builder;
    }
    public static IVersionedEndpointRouteBuilder MapProductApiV2(this IVersionedEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup(BaseUrl).HasApiVersion(2);
        group.MapPost(string.Empty, CreateProducts);

        return builder;
    }

    public static async Task<IResult> CreateProducts(ISender sender, [FromBody] Command.CreateProductCommand createProduct)
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
