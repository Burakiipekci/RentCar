using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidation: AbstractValidator<Rental>
    {
        public RentalValidation()
        {
            RuleFor(r => r.RentDate).NotNull();
        }
    }
}
