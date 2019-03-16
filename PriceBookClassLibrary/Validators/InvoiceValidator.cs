using System;
using FluentValidation;

namespace PriceBookClassLibrary.Validators
{
    public class InvoiceValidator : AbstractValidator<InvoiceModel>
    {
        public InvoiceValidator()
        {
            RuleFor(i => i.InvoiceNumber)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Length(0, 20).WithMessage("{PropertyName} should have a maximum of {MaxLength} characters.");

            RuleFor(i => i.InvoiceAmount)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .Must(beAPositiveNumber).WithMessage("{PropertyName} has to be a positive amount.");
        }

        private bool beAPositiveNumber(decimal num)
        {
            if (num > 0)
            {
                return true;
            }
            return false;
        }
    }
}
