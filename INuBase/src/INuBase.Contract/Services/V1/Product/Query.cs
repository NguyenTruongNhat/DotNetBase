using INuBase.Contract.Abstractions.Message;
using INuBase.Contract.Abstractions.Shared;
using INuBase.Contract.Enumerations;
using static INuBase.Contract.Services.V1.Product.Response;

namespace INuBase.Contract.Services.V1.Product;
public static class Query
{
    public record GetProductsQuery(string? SearchTerm, string? SortColumn, SortOrder? SortOrder, IDictionary<string, SortOrder>? SortColumnAndOrder, int PageIndex, int PageSize) : IQuery<PagedResult<ProductResponse>>;
    public record GetProductByIdQuery(Guid Id) : IQuery<ProductResponse>;
}
