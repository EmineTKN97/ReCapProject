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
    public class EfColorsDal : IEntityRepository<Colors>
    {
        public void Add(Colors entity)
        {
            using (RentACarContext rentContext = new())
            {
                var AddEntity = rentContext.Entry(entity);
                AddEntity.State = EntityState.Added;
                rentContext.SaveChanges();
            }
        }

        public void Delete(Colors entity)
        {
            using (RentACarContext rentContext = new())
            {
                var DeleteEntity = rentContext.Entry(entity);
                DeleteEntity.State = EntityState.Deleted;
                rentContext.SaveChanges();
            }
        }

        public Colors Get(Expression<Func<Colors, bool>> filter)
        {
            using (RentACarContext rentContext = new())
            {
                return rentContext.Set<Colors>().SingleOrDefault(filter);

            }
        }

        public List<Colors> GetAll(Expression<Func<Colors, bool>> filter = null)
        {
            using (RentACarContext rentContext = new())
            {
                return filter == null
                    ? rentContext.Set<Colors>().ToList()
                    : rentContext.Set<Colors>().Where(filter).ToList();
            }
        }

        public void Update(Colors entity)
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
