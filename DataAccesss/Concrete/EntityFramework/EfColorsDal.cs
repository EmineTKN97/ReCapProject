using Core.DataAccess.EntityFramework;
using DataAccesss.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.Concrete.EntityFramework
{
    public class EfColorsDal : EfEntityRepısitoryBase<Colors,RentACarContext>,IColorDal
    {
       
    }
}
