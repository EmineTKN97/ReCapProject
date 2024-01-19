using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
using DataAccesss.Abstract;
using DataAccesss.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;


internal class Program
{
    private static void Main(string[] args)
    {
        // CarTest();
        //CarBrandColor();
        RentalAdd();
    }

    private static void CarTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        var result = carManager.GetAll();
        if (result.Success ==true )
        {
            foreach (var car in carManager.GetAll().Data)
            {
                    Console.WriteLine(car.CarName);

            }
        }
       
    }





    private static void CarBrandColor()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        var result = carManager.GetCarDetails();
        if (result.Success == true)
        {
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);

            }

        }
    }
   
  
    private static void RentalAdd()
    {
        RentACarContext context = new RentACarContext();
        Rental rental1 = new Rental();
        rental1.CarId = 2;
        rental1.CustomerId = 7;
        rental1.RentDate = DateTime.Now;
        RentalManager rentalManager = new RentalManager(new EfRentalDal(context));
        
        if (rental1.ReturnDate == null)
        {
            Console.WriteLine(Messages.RentalInvalid);
        }
        else 
        {
            rentalManager.AddRental(rental1);
            Console.WriteLine(Messages.RentalAdded);
        }
    }



}
      