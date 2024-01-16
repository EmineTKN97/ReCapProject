using Core.DataAccess.EntityFramework;
using DataAccesss.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepısitoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailsDTO> GetCarDetails()
        {
            using (var context = new RentACarContext())
            {
                //3 tablo join etmiş oluyorum
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cr in context.Colors on c.ColorId equals cr.ColorId
                             select new CarDetailsDTO
                             {
                               
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cr.ColorName,
                                 DailyPrice = c.DailyPrice
                
                             };

                return result.ToList();
            }
        }
    }
}
