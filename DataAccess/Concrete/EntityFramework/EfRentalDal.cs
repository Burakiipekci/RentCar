using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailsDto(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {


                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join u in context.Userss
                             on r.CustomerId equals u.UserId


                             select new RentalDetailDto
                             {

                                 CarName = c.CarName,
                                 CarId = c.CarId,
                                 CustomerId = u.UserId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 UserName = u.FirstName,
                                 Id = r.Id




                             };
                return result.ToList();
            }
        }
    }
}
