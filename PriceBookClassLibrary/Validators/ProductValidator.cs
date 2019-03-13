using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .Length(2, 50).WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters.")
                .Must(beAPositiveNumber).WithMessage("{PropertyName} must be a positive whole number.")
                .Must(beNotBeABigNumber).WithMessage("{PropertyName} must be less than a million.");
        }

        protected bool beAValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            name = name.Replace("'", "");
            return name.All(Char.IsLetter);
        }

        protected bool beAPositiveNumber(int num)
        {
            if(num > 0)
            {
                return true;
            }
            return false;
        }

        protected bool beNotBeABigNumber(int num)
        {
            if(num > 0 && num < 1000000)
            {
                return true;
            }
            return false;
        }
    }
}