using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Businnes.Abstract;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService

    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }      
        
        [SecuredOperation("car.add, admin")]
        [ValidationAspect(typeof(CarValidation))]
        public IResult Add(Car car)
        {
          
             _carDal.Add(car);
            return new Result(true ,Message.CarAdded);
        }

        [ValidationAspect(typeof(CarValidation))]
        public IResult Delete(Car car)
        {
            _carDal.delete(car);
            return new Result(true, Message.CarDeleted);
        }

        [ValidationAspect(typeof(CarValidation))]
        public IDataResult<List<Car>> GetAll()
        {

            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Message.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Message.CarsListed);
        }

        [ValidationAspect(typeof(CarValidation))]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Message.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [ValidationAspect(typeof(CarValidation))]
        public IDataResult<List<Car>> GetCarId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(a => a.CarId== Id));
        }

        [ValidationAspect(typeof(CarValidation))]
        public IResult Update(Car car)
        {
            _carDal.update(car);
            return new Result(true, Message.CarUpdate);
        }


    
    }
}
