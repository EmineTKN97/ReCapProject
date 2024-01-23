using Core.DataAccess.EntityFramework;
using DataAccesss.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.Concrete.EntityFramework
{
public class EfUserDal:EfEntityRepısitoryBase<User, RentACarContext>, IUserDal
    {
        private readonly RentACarContext _context;

        public EfUserDal(RentACarContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var UserToDelete = _context.Users.FirstOrDefault(u => u.Id == id);

            if (UserToDelete != null)
            {
                _context.Users.Remove(UserToDelete);
                _context.SaveChanges();
            }

        }
    }
}
