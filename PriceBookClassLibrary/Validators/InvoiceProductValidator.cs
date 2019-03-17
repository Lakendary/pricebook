using FluentValidation;

namespace PriceBookClassLibrary.Validators
{
    public class InvoiceProductValidator : AbstractValidator<InvoiceProductModel>
    {
        public InvoiceProductValidator(bool weighted)
        {
            if (weighted)
            {
                RuleFor(ip => ip.Weight)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(beAPositiveNumber).WithMessage("{PropertyName} must be a positive number.")
                .Must(notBeABigNumber).WithMessage("{PropertyName} must be less than a million.");

                RuleFor(ip => ip.Quantity)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                    .Must(notBeABigNumber).WithMessage("{PropertyName} must be less than a million.");

                RuleFor(ip => ip.TotalPrice)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .Must(beAPositiveNumber).WithMessage("{PropertyName} must be a positive number.")
                    .Must(notBeABigNumber).WithMessage("{PropertyName} must be less than a million.");
            }
        }

        public InvoiceProductValidator()
        {
            RuleFor(ip => ip.Quantity)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .Must(notBeABigNumber).WithMessage("{PropertyName} must be less than a million.");

            RuleFor(ip => ip.TotalPrice)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(beAPositiveNumber).WithMessage("{PropertyName} must be a positive number.")
                .Must(notBeABigNumber).WithMessage("{PropertyName} must be less than a million.");
        }

        private bool beAPositiveNumber(decimal num)
        {
            if (num >= 0)
            {
                return true;
            }
            return false;
        }

        private bool beAPositiveNumber(int num)
        {
            if (num >= 0)
            {
                return true;
            }
            return false;
        }

        private bool notBeABigNumber(int num)
        {
            if (num >= 0 && num <= 1000000)
            {
                return true;
            }
            return false;
        }

        private bool notBeABigNumber(decimal num)
        {
            if (num >= 0 && num <= 1000000)
            {
                return true;
            }
            return false;
        }
    }
}
