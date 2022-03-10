using Business.Abstract;
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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof (ColorValidation))]
        public IDataResult<List<Color>> GetAll()
        {
           _colorDal.GetAll();
            return new DataResult<List<Color>>(_colorDal.GetAll(), true);
        }
      
        public IDataResult<List<Color>> GetByColorId(int ColorId)
        {
            if (ColorId < 1)
            {
                return new ErrorDataResult<List<Color>>(Message.ColorIdInvalid);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorId == ColorId));
        }
    }
    }

