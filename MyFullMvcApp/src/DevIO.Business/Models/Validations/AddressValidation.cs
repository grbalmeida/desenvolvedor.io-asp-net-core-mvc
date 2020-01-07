using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(a => a.Street)
                .NotEmpty().WithMessage("{PropertyName} field must be provided")
                .Length(2, 200).WithMessage("{PropertyName field must be between {MinLength} and {MaxLength} characters}");

            RuleFor(a => a.District)
                .NotEmpty().WithMessage("{PropertyName} field must be provided")
                .Length(2, 100).WithMessage("{PropertyName field must be between {MinLength} and {MaxLength} characters}");

            RuleFor(a => a.PostalCode)
                .NotEmpty().WithMessage("{PropertyName} field must be provided")
                .Length(8).WithMessage("{PropertyName} field must be {MaxLength} characters");

            RuleFor(a => a.City)
                .NotEmpty().WithMessage("{PropertyName} field must be provided")
                .Length(2, 100).WithMessage("{PropertyName field must be between {MinLength} and {MaxLength} characters}");

            RuleFor(a => a.State)
                .NotEmpty().WithMessage("{PropertyName} field must be provided")
                .Length(2, 50).WithMessage("{PropertyName field must be between {MinLength} and {MaxLength} characters}");

            RuleFor(a => a.Number)
                .NotEmpty().WithMessage("{PropertyName} field must be provided")
                .Length(1, 50).WithMessage("{PropertyName field must be between {MinLength} and {MaxLength} characters}");
        }
    }
}
