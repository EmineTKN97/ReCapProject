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
            var sonuc = _carImageDal.GetAll(c => c.CarId == id).Count();
            if (sonuc > 4)
            {
                return new ErrorResult(Messages.NotCarImage);
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

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == CarId));
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


    }

       
}





