using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public static class Messages
    {

        public static string Added = "Eklendi";
        public static string Deleted = "Silindi";
        public static string Updated = "Güncellendi";
        public static string NameInvalid = "İsim geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string Listed = "Listelendi";
        public static string CarIsNotReturned = "Araba geri dönmedi.";
        public static string ImagesLimitExceeded = "Maksimum görsel yüklendi";
        public static string DefaultImage = "Görsel yok Default görsel gönderilecek.";


        public static string CarNameAlreadyExists = "Aynı isimde başka bir araba var";
        public static string CategoryLimitExceded = "Kategori limiti aşıldı.";
        public static string AuthorizationDenied = "Yetki bulunamadı.";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
    }
}
