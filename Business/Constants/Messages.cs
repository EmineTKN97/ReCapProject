using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
public static class Messages
    {
        internal static readonly string CarImageUpdate;
        public static string CarAdded = "Araba başarı ile eklendi";
            public static string CarNameİnvalid = "Araba isimi 2 karakterden uzun olmalıdır.";
            public static string CarListed = "Arabalar listelendi.";
            public  static string ColorNameİnvalid ="Renk isimi 2 karakterden uzun olmalıdır.";
            public  static string ColorAdded ="Renk başarı ile eklendi";
            public  static string ColorListed ="Renkler listelendi";
            public static string BrandNameİnvalid ="Marka ismi 2 karakterden uzun olmalıdır";
            public static string BrandAdded="Marka başarı ile eklendi";
            public static string BrandDeleted="Marka başarı ile silindi";
            public static string BrandListed="Markalar başarı ile listelendi";
            public static string BrandUpdated="Marka Başarı ile güncellendi";
            public static string CarUpdated="Araba güncellendi";
            public static string CarDeleted="Araba silindi";
            public static string ColorUpdate="Renk güncellendi";
            public static string DeleteColor="Renk Silindi";
            public static string CompanyNameİnvalid ="Şirket isimi 2 karakterden küçük olmaz";
            public static string CustomerAdded="Müşteri başarıyla eklendi";
            public static string DeleteCustomer="Müşteri başarıyla silindi";
            public static string ListedCustomer="Müşteriler Listelendi";
            public static string CustomerUpdated="Müşteriler güncellendi";
            public static string Userİnvalid="Kullanıcı adı 2 karakterden uzun olmalıdır";
            public static string UserAdded="Kullanıcı eklendi";
            public static string DeleteUser="Kullanıcı silindi";
            public static string listedUsers="Kullanıcı listelendi";
            public static string UpdatedUser="Müşteri güncellendi";
            public static string RentalInvalid= "Arabanın kiralanabilmesi için arabanın teslim edilmesi gerekmektedir.";
            public static string RentalAdded="Araba kiralama başarılı";
            public static string DeleteRental="Araba kiralama işlemi silindi";
            public static string UpdatedRental="Kiralama işlemi günvellendi";
            public static string listedRental="Kiralamalar listelendi";
            public  static string CarImageNotAdded="Sadece 5 adet resim eklenebilir";
        public static string CarImageDeleted="resim silindi";
        public static string CarImageListed="resimler listelendi";
       public static string CarImageAdded="resim eklendi";
       public static string CarImageCountExceeded="resim sayısı fazla";
    }
}
