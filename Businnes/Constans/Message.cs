using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constans
{
   public static class Message
    {
        public static string MaintenanceTime = "Sistem Bakımda";



        #region Car
        public static string CarAdded = "Araba Eklendi";
        public static string CarDeleted = "Araba Silindi";
        public static string CarUpdate = "Arabalar listelendi";
        public static string CarNameInvalid = "Araba Eklendi";
        public static string CarsListed = "Arabalar listelendi";
        #endregion

        #region Brand
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandIdInvalid = "Marka ıd geçersiz";
        #endregion

        #region Color
        public static string ColorIdInvalid = "Renk ıd geçersiz";
        #endregion

        #region User
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserNotAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserListed = "Kullanıcılar listelendi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        #endregion

        #region Customer
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerListed = "Müşteri listelendi";
        #endregion

        #region Rental
        public static string CustomerInformationListed = "Kiralanan araba bilgileri listelendi.";
        public static string RentalAdded = "Araba kiralanma eklendi";
        public static string RentalUpdated = "Araba kiralanma güncellendi";
        #endregion


        public static string AuthorizationDenied = "Yetkiniz Yok"; 

        public static string ImageUploaded = "Resim başarıyla yüklendi";


    }
}
