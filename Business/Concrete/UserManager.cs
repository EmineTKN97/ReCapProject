using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccesss.Abstract;
using DataAccesss.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userdal;

        public UserManager(IUserDal userdal)
        {
            _userdal = userdal;
        }

        public IResult AddUser(User user)
        {
            if (user.FirstName.Length <= 2 && user.LastName.Length <=2)
            {
                return new ErrorResult(Messages.Userİnvalid);
            }
            _userdal.Add(user);
            return new Result(true, Messages.UserAdded);
        }

        public IResult DeleteUser(User user)
        {
            _userdal.Delete(user);
            return new Result(true, Messages.DeleteUser);
        }

        public IDataResult<List<User>> GetAll()
        {

            return new SuccessDataResult<List<User>>(_userdal.GetAll(), Messages.listedUsers);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userdal.Get(u => u.Id == id));
        }

        public IResult UpdateUser(User user)
        {
            _userdal.Update(user);
            return new Result(true, Messages.UpdatedUser);
        }
    }
}
