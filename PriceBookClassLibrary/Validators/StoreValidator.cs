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
            RuleFor(s => s.Name).NotEmpty();
        }
    }
}
