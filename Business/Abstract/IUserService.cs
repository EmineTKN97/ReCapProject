using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
public  interface IUserService
    {
        IDataResult<User> GetById(int id);
        IDataResult<List<User>> GetAll();
        IResult AddUser(User user);
        IResult UpdateUser(User user);
        IResult DeleteUser(int id);
    }
}
