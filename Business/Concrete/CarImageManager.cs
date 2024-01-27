using Business.Abstract;
using Business.Constants;
using Business.Helper;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccesss.Abstract;
using DataAccesss.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
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

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public async Task<IResult> AddCarImage(IFormFile _IFormFile, int id)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimit(id), GetDefaultImage(id));
            if (result != null)
            {
                return result;
            }
            else
            {
                string uniqueFileName = Guid.NewGuid().ToString();
                string fileExtension = Path.GetExtension(_IFormFile.FileName);
                string fileName = uniqueFileName + fileExtension;

                var filePath = Common.GetFilePath(fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await _IFormFile.CopyToAsync(fileStream);
                }

                _carImageDal.AddImage(fileName, id);

                return new SuccessResult(Messages.AddCarİmage);

            }

        }
        public IResult DeleteCarImage(int ImageId)
        {
            _carImageDal.Delete(ImageId);
            return new Result(true, Messages.DeleteCarImage);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }



        public IDataResult<List<CarImage>> GetById(int CarId)
        {

            var imageCheckResult = BusinessRules.Run(CheckImage(CarId));

            if (imageCheckResult != null)
            {
                _carImageDal.AddDefaultImage(CarId);
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == CarId));
            }
            return new ErrorDataResult<List<CarImage>>();

        }
        public async Task<IResult> UpdateCarImage(IFormFile file, int ıd)
        {
            string uniqueFileName = Guid.NewGuid().ToString();
            string fileExtension = Path.GetExtension(file.FileName);
            string fileName = uniqueFileName + fileExtension;

            var filePath = Common.GetFilePath(fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            _carImageDal.Update(fileName, ıd);

            return new SuccessResult(Messages.UpdateCarImage);

        }

        private IResult CheckIfImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(cı => cı.CarId == carId).Count();

            if (result >= 5)
            {
                return new ErrorResult(Messages.NotCarImage);
            }
            return new SuccessResult();
        }

        private IDataResult<CarImage> GetDefaultImage(int CarId)
        {
            CarImage defaultImage = new CarImage { CarId = CarId, Date = DateTime.Now, ImagePath = "default.jpg" };
            if (defaultImage != null)
            {
                _carImageDal.AddDefaultImage(CarId);
                return new SuccessDataResult<CarImage>(defaultImage);
            }
            else
            {
                return new ErrorDataResult<CarImage>("Varsayılan resim bulunamadı.");
            }

        }
        private IResult CheckImage(int carId)
        {
            var result = _carImageDal.GetAll(cı => cı.CarId == carId).Count();
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ImageNotError);

        }


    }


}





