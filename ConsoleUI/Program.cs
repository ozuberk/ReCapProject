using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"{car.CarId} Marka:{car.BrandName} Renk: {car.ColorName} Fiyatı: {car.DailyPrice}");
            }
        }
    }
}