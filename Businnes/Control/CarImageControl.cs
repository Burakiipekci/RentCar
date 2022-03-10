using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Control
{
    public class CarImageControl : ICarImageControl
    {
        ICarImageDal _carImageDal;

        public CarImageControl(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }
    }
}
