using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarImageUpdate = "resim güncellenmiştir";
        public static string CarAdded = "Araba başarı ile eklendi";
        public static string CarNameİnvalid = "Araba isimi 2 karakterden uzun olmalıdır.";
        public static string CarListed = "Arabalar listelendi.";
        public static string ColorNameİnvalid = "Renk isimi 2 karakterden uzun olmalıdır.";
        public static string ColorAdded = "Renk başarı ile eklendi";
        public static string ColorListed = "Renkler listelendi";
        public static string BrandNameİnvalid = "Marka ismi 2 karakterden uzun olmalıdır";
        public static string BrandAdded = "Marka başarı ile eklendi";
        public static string BrandDeleted = "Marka başarı ile silindi";
        public static string BrandListed = "Markalar başarı ile listelendi";
        public static string BrandUpdated = "Marka Başarı ile güncellendi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarDeleted = "Araba silindi";
        public static string ColorUpdate = "Renk güncellendi";
        public static string DeleteColor = "Renk Silindi";
        public static string CompanyNameİnvalid = "Şirket isimi 2 karakterden küçük olmaz";
        public static string CustomerAdded = "Müşteri başarıyla eklendi";
        public static string DeleteCustomer = "Müşteri başarıyla silindi";
        public static string ListedCustomer = "Müşteriler Listelendi";
        public static string CustomerUpdated = "Müşteriler güncellendi";
        public static string Userİnvalid = "Kullanıcı adı 2 karakterden uzun olmalıdır";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string DeleteUser = "Kullanıcı silindi";
        public static string listedUsers = "Kullanıcı listelendi";
        public static string UpdatedUser = "Müşteri güncellendi";
        public static string RentalInvalid = "Arabanın kiralanabilmesi için arabanın teslim edilmesi gerekmektedir.";
        public static string RentalAdded = "Araba kiralama başarılı";
        public static string DeleteRental = "Araba kiralama işlemi silindi";
        public static string UpdatedRental = "Kiralama işlemi günvellendi";
        public static string listedRental = "Kiralamalar listelendi";
        public static string DeleteCarImage = "Resim silindi";
        public static string UpdateCarImage = "Resim Güncellendi";
        public static string NotCarImage = "Bir araba için en fazla 5 resim eklenebilir";
        public static string AddCarİmage = "resim başarı ile eklendi";
        public static string ImageNotError = "Resim bulunamamdı";
        public static string AddDefaultCarImage = "Default resim eklendi";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre  hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
