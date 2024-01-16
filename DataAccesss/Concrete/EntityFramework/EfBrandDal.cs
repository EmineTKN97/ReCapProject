using DataAccesss.Abstract;
using Core.DataAccess.EntityFramework;
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
    public class EfBrandDal : EfEntityRepısitoryBase<Brand, RentACarContext>, IBrandDal
    {
      
    }
 }
   
