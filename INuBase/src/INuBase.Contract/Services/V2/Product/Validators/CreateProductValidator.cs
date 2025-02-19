using FluentValidation;

namespace INuBase.Contract.Services.V2.Product.Validators;
public class CreateProductValidator : AbstractValidator<Command.CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Price).GreaterThan(10);
    }
}
