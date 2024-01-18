using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccesss.Abstract;
using DataAccesss.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {

        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult AddColor(Colors color)
        {
            if (color.ColorName.Length <= 2 )
            {
                return new ErrorResult(Messages.ColorNameİnvalid);
            }
            _colorDal.Add(color);
            return new Result(true, Messages.ColorAdded);
        }

        public IResult DeleteColor(Colors color)
        {
            _colorDal.Delete(color);
            return new Result(true,Messages.DeleteColor);
        }

        public IDataResult<List<Colors>> GetAll()
        {
            return new SuccessDataResult<List<Colors>>(_colorDal.GetAll(), Messages.ColorListed);
        }

        public IDataResult<Colors> GetById(int id)
        {
            return new SuccessDataResult<Colors>(_colorDal.Get(c => c.ColorId == id));
        }

        public IResult UpdateColor(Colors color)
        {
            _colorDal.Update(color);
            return new Result(true, Messages.ColorUpdate);
        }
    }
}
