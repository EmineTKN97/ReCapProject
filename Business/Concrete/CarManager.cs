using Business.Abstract;
using DataAccesss.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _Icardal;

        public CarManager(ICarDal cardal)
        {
            _Icardal = cardal;
        }

        public List<Car> GetAll()
        {
            return _Icardal.GetAll();
        }
    }
}

