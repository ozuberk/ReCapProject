using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFRentalDal : EfEntityRepositoryBase<Rental, RecapContext>, IRentalDal
    {
        public Rental GetUnreturnedCar(int carId)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = context.Set<Rental>().Where(r => r.CarId == carId && r.ReturnDate == null);

                return result.SingleOrDefault();
            }
        }
    }
}
