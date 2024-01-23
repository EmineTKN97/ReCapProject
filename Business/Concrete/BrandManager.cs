using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccesss.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IResult AddBrand(Brand brand)
        {
            if (brand.BrandName.Length <= 2)
            {
                return new ErrorResult(Messages.BrandNameİnvalid);
            }
            _brandDal.Add(brand);
            return new Result(true, Messages.BrandAdded);
        }

        public IResult DeleteBrand(Brand brand)
        {
            _brandDal.Delete(brand);
            return new Result(true,Messages.BrandDeleted);
        }

      

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id));
        }

        public IResult UpdateBrand(Brand brand)
        {
            _brandDal.Update(brand);
            return new Result(true, Messages.BrandUpdated);

        }
    }
}
