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
    public class EfBrandDal : IEntityRepository<Brand>
    {
        public void Add(Brand entity)
        {
            using (RentACarContext rentContext = new())
            {
                var AddEntity = rentContext.Entry(entity);
                AddEntity.State = EntityState.Added;
                rentContext.SaveChanges();
            }

        }

        public void Delete(Brand entity)
        {
            using (RentACarContext rentContext = new())
            {
                var DeleteEntity = rentContext.Entry(entity);
                DeleteEntity.State = EntityState.Deleted;
                rentContext.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (RentACarContext rentContext = new())
            {
                return rentContext.Set<Brand>().SingleOrDefault(filter);

            }
        }

            public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
            {
                using (RentACarContext rentContext = new())
                {
                    return filter == null
                        ? rentContext.Set<Brand>().ToList()
                        : rentContext.Set<Brand>().Where(filter).ToList();
                }
            }

            public void Update(Brand entity)
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
   
