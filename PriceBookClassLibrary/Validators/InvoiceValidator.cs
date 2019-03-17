using FluentValidation;

namespace PriceBookClassLibrary.Validators
{
    public class InvoiceValidator : AbstractValidator<InvoiceModel>
    {
        public InvoiceValidator()
        {
            RuleFor(i => i.InvoiceNumber)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Length(0, 20).WithMessage("{PropertyName} must have a maximum of {MaxLength} characters.");

            RuleFor(i => i.InvoiceAmount)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .Must(beAPositiveNumber).WithMessage("{PropertyName} must to be a positive amount.")
                .Must(notBeABigNumber).WithMessage("{PropertyName} must be less than a million.");
        }

        private bool beAPositiveNumber(decimal num)
        {
            if (num > 0)
            {
                return true;
            }
            return false;
        }

        private bool notBeABigNumber(decimal num)
        {
            if (num > 0 && num < 1000000)
            {
                return true;
            }
            return false;
        }
    }
}
