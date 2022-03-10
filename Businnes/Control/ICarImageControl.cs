using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Control
{
    public interface ICarImageControl
    {
        IResult CheckIfCarImageLimit(int carId);
        IDataResult<List<CarImage>> GetDefaultImage(int carId);
        IResult CheckCarImage(int carId);
    }
}
