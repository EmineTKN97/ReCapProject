﻿using Core.DataAccess.EntityFramework;
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
    public class EfRentalDal : EfEntityRepısitoryBase<Rental, RentACarContext>, IRentalDal
    {
        private readonly RentACarContext _context;

        public EfRentalDal(RentACarContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var RentalToDelete = _context.Rentals.FirstOrDefault(r => r.Id == id);

            if (RentalToDelete != null)
            {
                _context.Rentals.Remove(RentalToDelete);
                _context.SaveChanges();
            }

        }
    }
        
}






