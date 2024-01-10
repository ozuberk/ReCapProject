using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : ICarDal
    {
        RecapContext _context;
        public EFCarDal(RecapContext context)
        {
            _context = context;
        }
        public void Add(Car entity)
        {
            var addCar = _context.Entry(entity);
            addCar.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(Car entity)
        {
            var deletedCar = _context.Entry(entity);
            deletedCar.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return _context.Set<Car>().SingleOrDefault();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<Car>().ToList()
                : _context.Set<Car>().Where(filter).ToList();

        }

        public void Update(Car entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
