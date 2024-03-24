using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class IMCarDal : ICarDal
    {
        List<Car> _cars;
        public IMCarDal()
        {
            _cars = new List<Car>
            {
                new Car {CarId=1,BrandId=1,ColorId=4,ModelYear=new DateTime(2022,12,15),DailyPrice=3500,Description="Lüks Sınıf Otomatik Vites"},
                new Car {CarId=2,BrandId=1,ColorId=5,ModelYear=new DateTime(2020,12,15),DailyPrice=3000,Description="Lüks Sınıf Otomatik Vites"},
                new Car {CarId=3,BrandId=2,ColorId=1,ModelYear=new DateTime(2002,12,15),DailyPrice=2500,Description="Orta Sınıf Manuel Vites"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }
        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public Car GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).FirstOrDefault();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            carToDelete.BrandId = car.BrandId;
            carToDelete.ColorId = car.ColorId;
            carToDelete.ModelYear = car.ModelYear;
            carToDelete.DailyPrice = car.DailyPrice;
            carToDelete.Description = car.Description;
        }
    }
}
