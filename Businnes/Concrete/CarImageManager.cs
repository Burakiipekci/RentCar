
using Business.Abstract;
using Business.Constans;
using Business.Control;
using Core.Helpers.FileHelper;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        ICarImageControl _carImageControl;
        

        public CarImageManager(IFileHelper fileHelper, ICarImageDal carImageDal, ICarImageControl carImageControl)
        {
            _fileHelper = fileHelper;
            _carImageDal = carImageDal;
            _carImageControl = carImageControl;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(_carImageControl.CheckIfCarImageLimit(carImage.CarId));
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Message.ImageUploaded);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImageDal.delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(_carImageControl.CheckCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(_carImageControl.GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _carImageDal.update(carImage);
            return new SuccessResult();
        }
    
    }
    }
