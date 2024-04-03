using Business.Abstract;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
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
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(CarImage carImage, IFormFile file)
        {
            var result = BusinessRules.Run(
                CheckIfCarImage(carImage.CarId),
                CheckIfCarImagesLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Add(PathConstants.ImagesPath, file);
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.Added);

        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId), Messages.Listed);

        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            var result = BusinessRules.Run(
                CheckIfCarImage(carImage.CarId),
                CheckIfCarImagesLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Update(PathConstants.ImagesPath + carImage.ImagePath, file, PathConstants.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Updated);
        }



        private IResult CheckIfCarImagesLimit(int carId)
        {
            var carImagesCount = _carImageDal.GetAll(c => c.CarId == carId).Count();
            if (carImagesCount >= 5)
            {
                return new ErrorResult(Messages.ImagesLimitExceeded);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarImage(int carId)
        {
            var carImagesCount = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (carImagesCount)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ImagesLimitExceeded);

        }

        public IDataResult<CarImage> GetById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.ImageId == Id), Messages.Listed);
        }
    }
}
