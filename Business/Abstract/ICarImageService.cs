using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public  interface ICarImageService
    {
        IDataResult<List<CarImage>> GetById(int CarId);
        IDataResult<List<CarImage>> GetAll();
        Task<IResult> AddCarImage(IFormFile _IFormFile, int id);

        IResult DeleteCarImage(int ImageId);
        Task<IResult> UpdateCarImage(IFormFile file, int carImageId);
    }
}
