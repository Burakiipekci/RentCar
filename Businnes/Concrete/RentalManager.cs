using Business.Abstract;
using Business.Constans;
using Businnes.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Message.RentalAdded);

        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Message.CustomerInformationListed);
        }

        public IDataResult<Rental> GetRentalByCustomerId(int id)
        {
           return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CustomerId == id));
        }

        public IDataResult<Rental> GetRentalById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailsDto(), Message.CustomerInformationListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsDto(int id)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailsDto(r => r.CarId == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.update(rental);
            return new SuccessResult(Message.RentalUpdated);
        }
    }
}
