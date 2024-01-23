using Core.DataAccess.EntityFramework;
using DataAccesss.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.Concrete.EntityFramework
{
public class EfCustomerDal:EfEntityRepısitoryBase<Customer, RentACarContext>, ICustomerDal
    {
        private readonly RentACarContext _context;

        public EfCustomerDal(RentACarContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var CustomerToDelete = _context.Customers.FirstOrDefault(c => c.Id == id);

            if (CustomerToDelete != null)
            {
                _context.Customers.Remove(CustomerToDelete);
                _context.SaveChanges();
            }

        }
    }
}
