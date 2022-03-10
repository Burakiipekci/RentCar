using Core.Entites.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class UserValidation:AbstractValidator<User>
    {
        public UserValidation()
        {
            //RuleFor(u => u.FirstName).MinimumLength(3);
            //RuleFor(u => u.FirstName).NotEmpty();
            //RuleFor(u => u.LastName).NotEmpty();
            //RuleFor(u => u.LastName).MinimumLength(1);
            //RuleFor(u => u.Password).MinimumLength(3);
            //RuleFor(u => u.Password).NotEmpty();


        }
    }
}
