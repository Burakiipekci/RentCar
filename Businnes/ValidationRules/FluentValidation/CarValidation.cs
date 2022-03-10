using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CarValidation:AbstractValidator<Car>
    {
        public CarValidation()
        {
           
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.CarName).MinimumLength(2);

         
        }
    }
}
