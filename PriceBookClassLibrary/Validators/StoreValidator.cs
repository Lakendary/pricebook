using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBookClassLibrary.Validators
{
    public class StoreValidator : AbstractValidator<StoreModel>
    {
        public StoreValidator()
        {
            RuleFor(s => s.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .Length(2, 50).WithMessage("{PropertyName} can only have {MinLength} to {MaxLength} characters.")
                .Must(beAValidStoreName).WithMessage("{PropertyName} has invalid characters.");

            RuleFor(s => s.Location)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .Length(2, 50).WithMessage("{PropertyName} can only have {MinLength} to {MaxLength} characters.")
                .Must(beAValidStoreName).WithMessage("{PropertyName} has invalid characters.");
        }

        protected bool beAValidStoreName(string storeName)
        {
            storeName = storeName.Replace(" ", "");
            storeName = storeName.Replace("-", "");
            return storeName.All(Char.IsLetter);
        }
    }
}
