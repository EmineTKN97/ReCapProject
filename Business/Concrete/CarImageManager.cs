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

        public async Task<string> AddCarImage(IFormFile _IFormFile,int id)
        {      
            var result = _carImageDal.GetAll(c => c.CarId == id).Count();
            if (result > 5)
            {
                return "ekleme yapamazsınız";
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

                return fileName;
            }
           
        }
        public IResult DeleteCarImage(int ImageId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImage> GetById(int CarId)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateCarImage(CarImage carImage)
        {
            throw new NotImplementedException();
        }
     

    }
}
