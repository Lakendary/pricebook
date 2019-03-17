using FluentValidation;
using System;
using System.Linq;

namespace PriceBookClassLibrary.Validators
{
    public class ProductValidator : AbstractValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Description)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .Length(2, 50).WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters.")
                .Must(beAValidName).WithMessage("{PropertyName} has invalid characters.");

            RuleFor(p => p.BrandName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .Length(2, 50).WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters.")
                .Must(beAValidName).WithMessage("{PropertyName} has invalid characters.");

            RuleFor(p => p.PackSize)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(beAPositiveNumber).WithMessage("{PropertyName} must be a positive whole number.")
                .Must(notBeABigNumber).WithMessage("{PropertyName} must be less than a million.");
        }

        private bool beAValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            name = name.Replace("'", "");
            name = name.Replace("&", "");
            name = name.Replace("+", "");
            return name.All(Char.IsLetter);
        }

        private bool beAPositiveNumber(int num)
        {
            if(num > 0)
            {
                return true;
            }
            return false;
        }

        private bool notBeABigNumber(int num)
        {
            if(num > 0 && num < 1000000)
            {
                return true;
            }
            return false;
        }
    }
}