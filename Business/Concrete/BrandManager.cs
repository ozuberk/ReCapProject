﻿using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new Result(true, Messages.Added);

        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new Result(true, Messages.Deleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new DataResult<List<Brand>>(_brandDal.GetAll(), true, Messages.Listed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id));
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new Result(true, Messages.Updated);

        }
    }
}
