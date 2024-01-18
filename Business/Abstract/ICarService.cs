using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {

        IDataResult<Car> GetById(int id);
         IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetCarsByBrandId(int BrandId);
        IDataResult<Car> GetCarsByColorId(int ColorId);
        IResult AddCar(Car car);
        IDataResult<List<CarDetailsDTO>> GetCarDetails();
        IResult UpdateCar(Car car);
        IResult DeleteCar(Car car);
    }
}
