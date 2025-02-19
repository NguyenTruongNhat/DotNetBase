using INuBase.Contract.Abstractions.Message;
using INuBase.Contract.Abstractions.Shared;
using INuBase.Domain.Abstractions.Dappers;

namespace INuBase.Application.UserCases.V2.Command.Products;
public sealed class CreateProductCommandHandler : ICommandHandler<INuBase.Contract.Services.V2.Product.Command.CreateProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(INuBase.Contract.Services.V2.Product.Command.CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Domain.Entities.Products.Product.CreateProduct(Guid.NewGuid(), request.Name, request.Price, request.Description);

        var result = await _unitOfWork.Products.AddAsync(product);

        return Result.Success(result);
    }
}
