using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.Abstract
{
    public interface ICarImageDal : IEntityRepository<CarImage>
    {
        void AddImage(string fileName, int id);
        void Delete(int ımageId);
        void Update(string fileName, int ıd);
        public void AddDefaultImage(int carId);
    }
}
