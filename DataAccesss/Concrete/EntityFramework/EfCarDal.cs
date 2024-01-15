using DataAccesss.Abstract;
using Entities.Abstract;
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
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (RentACarContext rentContext = new())
            {
                var DeleteEntity = rentContext.Entry(entity);
                DeleteEntity.State = EntityState.Deleted;
                rentContext.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentACarContext rentContext = new())
            {
                return rentContext.Set<Car>().SingleOrDefault(filter);
                    
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext rentContext = new())
            {
                return filter == null
                    ? rentContext.Set<Car>().ToList()
                    : rentContext.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (RentACarContext rentContext = new())
            {
                var UpdateEntity = rentContext.Entry(entity);
                UpdateEntity.State = EntityState.Modified;
                rentContext.SaveChanges();
            }
        }
    }
}
