using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.Abstract
{
   public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand brand);
        IResult Delete(Brand brand);
        IDataResult<List<Brand>> GetAllByBrandsId(int id);   

    }
}
