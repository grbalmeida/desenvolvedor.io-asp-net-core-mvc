using DevIO.Business.Models.Validations.Documents;
using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class SupplierValidation : AbstractValidator<Supplier>
    {
        public SupplierValidation()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("{PropertyName} field must be provided")
                .Length(2, 100).WithMessage("{PropertyName field must be between {MinLength} and {MaxLength} characters}");

            When(s => s.SupplierType == SupplierType.NaturalPerson, () =>
            {
                RuleFor(s => s.Document.Length).Equal(CpfValidation.CpfSize)
                    .WithMessage("Document field must be {ComparisonValue} characters long and has been provided {PropertyValue}.");

                RuleFor(s => CpfValidation.Validate(s.Document)).Equal(true)
                    .WithMessage("The document provided is invalid");
            });

            When(s => s.SupplierType == SupplierType.LegalEntity, () =>
            {
                RuleFor(s => s.Document.Length).Equal(CnpjValidation.CnpjSize)
                    .WithMessage("Document field must be {ComparisonValue} characters long and has been provived {PropertyValue}");

                RuleFor(s => CnpjValidation.Validate(s.Document)).Equal(true)
                    .WithMessage("The document provided is invalid");
            });
        }
    }
}
