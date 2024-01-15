using Business.Abstract;
using DataAccesss.Abstract;
using DataAccesss.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void AddCar(Car car)
        {
            if (car.Name.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else if (car.Name.Length < 2)
            {
                Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır!");
            }
            else if (car.DailyPrice > 0)
            {
                Console.WriteLine("Araba günlük fiyatı 0'dan büyük olmalıdır!");
            }
            Console.WriteLine("Araba Başarıyla Eklendi");
        }

      
        public List<Car> GetById(int id)
        {
            return _carDal.GetAll(c => c.Id == id);
        }

        public List<Car> GetCarsByBrandId(int BrandId)
        {
            return _carDal.GetAll(c => c.BrandId == BrandId);
        }

        public List<Car> GetCarsByColorId(int ColorId)
        {
            return _carDal.GetAll(c => c.ColorId == ColorId);
        }
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext Context = new())
            {
                return filter == null
                    ? Context.Set<Car>().ToList()
                    : Context.Set<Car>().Where(filter).ToList();

            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
    }
}
