using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace PriceBookClassLibrary.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryModel>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .Length(2, 50).WithMessage("{PropertyName} can only have {MinLength} to {MaxLength} characters.")
                .Must(beAValidName).WithMessage("{PropertyName} has invalid characters.");

            RuleFor(c => c.MainCategory)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Length(0, 50).WithMessage("{PropertyName} can only have {MaxLength} characters.")
                .Must(beAValidName).WithMessage("{PropertyName} has invalid characters.");
        }

        protected bool beAValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetter);
        }
    }
}
