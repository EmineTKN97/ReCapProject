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
        IDataResult<CarImage> GetById(int CarId);
        IDataResult<List<CarImage>> GetAll();
        Task<string> AddCarImage(CarİmageDTO imageDto);
        IResult UpdateCarImage(CarImage carImage);
        IResult DeleteCarImage(int ImageId);
    }
}
