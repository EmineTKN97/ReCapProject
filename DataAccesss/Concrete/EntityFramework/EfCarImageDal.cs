using Core.DataAccess.EntityFramework;
using DataAccesss.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccesss.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepısitoryBase<CarImage, RentACarContext>, ICarImageDal
    {
        
        void ICarImageDal.AddImage(string fileName, int id)
        {

            using (var dbContext = new RentACarContext())
            {
                var imageEntity = new CarImage
                {
                    ImagePath = fileName,
                    CarId = id,
                    Date = DateTime.Now,

                };

                dbContext.CarImages.Add(imageEntity);
                dbContext.SaveChanges();
            }
        }
    } 
}
