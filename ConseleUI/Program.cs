using Business.Concrete;
using DataAccesss.Concrete.InMemory;

CarManager carManager = new CarManager(new InMemoryCarDal());
foreach (var car in carManager.GetAll())
{
    string output = $"carId ={car.Id} BrandId={car.BrandId} ColorId={car.ColorId} Description={car.Description} DailyPrice={decimal.ToInt32(car.DailyPrice)}";
    Console.WriteLine(output);
}