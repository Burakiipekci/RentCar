using Business.Abstract;
using Business.Constans;
using Businnes.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Message.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.delete(customer);
            return new SuccessResult(Message.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {

            var result = _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Message.CustomerListed);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.update(customer);
            return new SuccessResult(Message.CustomerUpdated);
        }
    }
}
