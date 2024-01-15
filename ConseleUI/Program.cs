using Business.Concrete;
using DataAccesss.Concrete.EntityFramework;
using Entities.Concrete;
using System;


internal class Program
{
    private static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new EfCarDal());
        foreach (var car in carManager.GetAll())
        {
            Console.WriteLine(car.Name);

        }
    }
}