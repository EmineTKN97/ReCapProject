using DataAccesss.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorsManager
    {
        IColorDal _Icolordal;

        public ColorsManager(IColorDal colorDal)
        {
            _Icolordal = colorDal;
        }

      

        public List<Colors> GetAll()
        {
            return _Icolordal.GetAll();
        }
    }
}
