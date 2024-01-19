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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentaldal;

        public RentalManager(IRentalDal rentaldal)
        {
            _rentaldal = rentaldal;
        }

        public IResult AddRental(Rental rental)
        {
            var isRented = _rentaldal.Get(r => r.ReturnDate == null && r.CarId == rental.CarId);

            if (isRented != null)
            {
                return new ErrorResult(Messages.RentalInvalid);
            }

            _rentaldal.Add(rental);

            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult DeleteRental(Rental rental)
        {
            _rentaldal.Delete(rental);
            return new Result(true, Messages.DeleteRental);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentaldal.GetAll(), Messages.listedRental);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentaldal.Get(u => u.Id == id));
        }

        public IResult UpdateRental(Rental rental)
        {
            _rentaldal.Update(rental);
            return new Result(true, Messages.UpdatedRental);
        }
    }
}
       