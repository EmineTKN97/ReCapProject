using DataAccesss.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
   public class BrandManager
    {

        IBrandDal _Ibranddal;

        public BrandManager(IBrandDal brandDal)
        {
            _Ibranddal = brandDal;
        }

        public List<Brand> GetAll()
        {
            return _Ibranddal.GetAll();
        }
    }
}
