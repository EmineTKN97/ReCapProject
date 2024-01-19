using Core.DataAccess.EntityFramework;
using DataAccesss.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepısitoryBase<Rental, RentACarContext>, IRentalDal
    {
        private readonly RentACarContext _context;

        public EfRentalDal(RentACarContext context)
        {
            _context = context;
        }
        public void AddRental(Rental rental)
        {
            using (var context = _context)
            {
                var newRental = new Rental
                {
                    Id = rental.Id,
                    CustomerId = rental.CustomerId,
                    CarId = rental.CarId,
                    RentDate = rental.RentDate, 
                    ReturnDate = rental.ReturnDate,

                };

                context.Rentals.Add(newRental);
                var customer = context.Customers.FirstOrDefault(cr => cr.Id == rental.CustomerId);
                if (customer != null)
                {
                    rental.CustomerId = customer.Id;
                }
                var car = context.Cars.FirstOrDefault(c => c.Id == rental.CarId);
                if (car != null) 
                {
                rental.CarId = car.Id;  
                }
                context.SaveChanges();

            }
        }

    }

}

