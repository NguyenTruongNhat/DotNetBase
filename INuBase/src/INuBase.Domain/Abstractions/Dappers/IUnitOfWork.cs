using INuBase.Domain.Abstractions.Dappers.Repositories.Product;

namespace INuBase.Domain.Abstractions.Dappers;
public interface IUnitOfWork
{
    IProductRepository Products { get; }
}
