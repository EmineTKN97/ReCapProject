using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public  interface IColorService
    {

        IDataResult<Colors> GetById(int id);
        IDataResult<List<Colors>> GetAll();
        IResult AddColor(Colors color);
        IResult UpdateColor(Colors color);
        IResult DeleteColor(Colors color);
    }
}
