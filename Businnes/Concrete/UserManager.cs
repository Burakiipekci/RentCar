using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Businnes.Abstract;

using Core.Aspect.Autofac.Validation;
using Core.Entites.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidation))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Message.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.delete(user);
            return new SuccessResult(Message.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Message.UserListed);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IResult Update(User user)
        {
            _userDal.update(user);
            return new SuccessResult(Message.UserUpdated);
        }
    }
}
