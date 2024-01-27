using Core.DataAccess.EntityFramework;
using DataAccesss.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccesss.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepısitoryBase<CarImage, RentACarContext>, ICarImageDal
    {
        private readonly RentACarContext _context;

        public EfCarImageDal(RentACarContext context)
        {
            _context = context;
        }
        public void Delete(int ımageId)
        {
            var ImageToDelete = _context.Rentals.FirstOrDefault(r => r.Id == ımageId);

            if (ImageToDelete != null)
            {
                _context.Rentals.Remove(ImageToDelete);
                _context.SaveChanges();
            }
        }

      
        public void Update(string fileName, int ıd)
        {
            using (var context = new RentACarContext())
            {
                // Güncellenen CarImage'ın var olup olmadığını kontrol et
                var existingCarImage = context.CarImages.SingleOrDefault(ci => ci.Id == ıd);

                if (existingCarImage != null)
                {
                    // CarImage'ın özelliklerini güncelle
                    existingCarImage.ImagePath = fileName;

                    // Diğer özellikleri de güncelleyebilirsiniz

                    // Değişiklikleri kaydet
                    context.SaveChanges();
                }
                else
                {
                    // Belirtilen Id'ye sahip bir CarImage bulunamadıysa, hata mesajı dönebilirsiniz.
                    // veya hata durumunu başka bir şekilde ele alabilirsiniz.
                    throw new Exception("Belirtilen Id'ye sahip bir CarImage bulunamadı.");
                }

            }
        }
        void ICarImageDal.AddImage(string fileName, int id){ 
            

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
        public void AddDefaultImage(int carId)
        {
            using (var dbContext = new RentACarContext())
            {
                CarImage defaultImage = new CarImage
            {
                CarId = carId,
                Date = DateTime.Now,
                ImagePath = "default.jpg"
            };

            dbContext.CarImages.Add(defaultImage);
            dbContext.SaveChanges();
        }
    }
} 
}
