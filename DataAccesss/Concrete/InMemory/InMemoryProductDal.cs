using DataAccesss.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;


        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
            new Car{ BrandId= 1, ColorId=2, DailyPrice= 5000,  Description="Araba", Id=1,  ModelYear=1999},
            new Car{ BrandId= 1, ColorId=2, DailyPrice= 10000,  Description="Araba2", Id=2,  ModelYear=2001},
            new Car{ BrandId= 2, ColorId=3, DailyPrice= 5500,  Description="Araba3", Id=3,  ModelYear=2012},
            new Car{ BrandId= 2, ColorId=1, DailyPrice= 56000,  Description="Araba4", Id=4,  ModelYear=2023},
            };


        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car CarDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(CarDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();

        }

        public void Update(Car car)
        {
            Car UpdateCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            UpdateCar.BrandId = car.BrandId;
            UpdateCar.ColorId = car.ColorId;
            UpdateCar.DailyPrice = car.DailyPrice;
            UpdateCar.Description = car.Description;
            UpdateCar.ModelYear = car.ModelYear;

        }
    }
}