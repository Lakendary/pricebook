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
                .NotEmpty().WithMessage("The store name cannot be empty.")
                .Length(2, 50).WithMessage("The store name must have 2 to 50 characters.")
                .Must(beAValidStoreName).WithMessage("The store name has invalid characters.");
        }

        protected bool beAValidStoreName(string storeName)
        {
            storeName = storeName.Replace(" ", "");
            storeName = storeName.Replace("-", "");
            return storeName.All(Char.IsLetter);
        }
    }
}
