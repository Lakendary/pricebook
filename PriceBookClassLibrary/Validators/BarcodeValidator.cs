using FluentValidation;

namespace PriceBookClassLibrary.Validators
{
    public class BarcodeValidator : AbstractValidator<BarcodeModel>
    {
        public BarcodeValidator()
        {
            RuleFor(b => b.Barcode)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .Length(2, 50).WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters.");
        }
    }
}
