using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} field must be provided")
                .Length(2, 200).WithMessage("{PropertyName field must be between {MinLength} and {MaxLength} characters}");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} field must be provided")
                .Length(2, 1000).WithMessage("{PropertyName field must be between {MinLength} and {MaxLength} characters}");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("{PropertyName} field must be greater than {ComparisonValue}");
        }
    }
}
