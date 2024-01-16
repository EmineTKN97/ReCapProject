using Business.Concrete;
using DataAccesss.Concrete.EntityFramework;
using Entities.Concrete;
using System;


internal class Program
{
    private static void Main(string[] args)
    {
        // CarTest();
        CarBrandColor();
    }

    private static void CarTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        foreach (var car in carManager.GetAll())
        {
      //      Console.WriteLine(car.CarName);

        }
    }
 
    
  
    

    private static void CarBrandColor()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        foreach (var car in carManager.GetCarDetails())
        {
            Console.WriteLine(car.CarName +"/"+ car.BrandName +"/"+ car.ColorName + "/" + car.DailyPrice);

        }
    }
}