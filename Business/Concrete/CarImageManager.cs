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

        public async Task<string> AddCarImage(CarİmageDTO imageDto)
        {
            //IResult result = BusinessRules.Run(CheckCarImageCountofCarCorrect(id));
            {

                string FileName = "";
                try
                {
                    FileInfo _FileInfo = new FileInfo(imageDto.İmagePath.FileName);
                    FileName = Guid.NewGuid().ToString();
                    var _GetFilePath = Common.GetFilePath(imageDto.İmagePath.FileName);

                    // Resmi bilgisayara kaydet
                    using (var _FileStream = new FileStream(_GetFilePath, FileMode.Create))
                    {
                        await imageDto.İmagePath.CopyToAsync(_FileStream);
                    }

                    // Veritabanına dosya yolunu ve diğer bilgileri kaydet
                    Add(FileName, imageDto.CarId);

                    return FileName;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void Add(string image,int CarId)
        {
            using (var context = new RentACarContext())
            {
                var imageEntity = new CarImage
                {
                    CarId = CarId,
                    ImagePath = image,
                    Date = DateTime.Now,
                };

                context.CarImages.Add(imageEntity);
                context.SaveChanges();
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
       /* private IResult CheckCarImageCountofCarCorrect(int CarId)
        {
            var result = _carImageDal.GetAll(cı => cı.CarId == CarId).Count();
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageNotAdded);

            }
            return new SuccessResult();
        
        }
       */
        
    }
}
