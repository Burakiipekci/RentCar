using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Businnes.Abstract;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager( IBrandDal brandDal)
        {
      
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidation))]
        public IResult Add(Brand brand)
        {
           _brandDal.Add(brand);

            return new SuccessResult(Message.BrandAdded);
        }

        
        public IResult Delete(Brand brand)
        {
            _brandDal.delete(brand);
            return new ErrorResult(Message.BrandDeleted);
        }

        
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());


        }

        public IDataResult<List<Brand>> GetAllByBrandsId(int id)
        {
           
            return new DataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandId == id), true, Message.BrandIdInvalid);
        }
    }
}
