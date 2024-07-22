using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcRehber.Models.Entities
{
    [Table("Kisiler")]
    public class Kisi
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("İsim")]
        public string Ad { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Soyisim")]
        public string Soyad { get; set; }


        [DataType(DataType.PhoneNumber)]
        [DisplayName("Ev numarası")]
        public string EvTelefon { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Kişisel Numara")]
        public string CepTelefon { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("İş numarası")]
        public string IsTelefon { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("E-mail adresi")]
        public string EmailAdres { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Adres")]
        public string Adres { get; set; }

        [DisplayName("Şehir")]
        //city classından aldığımız şehir kodunu burada city_number_info değişkeni ile kullanıyoruz.
        public int SehirId { get; set; }
        //yani bununla şehir tablosundaki bilgilere ulaşmış olacağız.(bağlantı)  

        public int CurrentId {  get; set; }//girdiyi yapan kullanıcıyı gösterecek

        //city tipinde bir property oluşturuyoruz böylece
        public Sehir Sehir { get; set; }

        public TBLUserInfo TBLUserInfo { get; set; }
    }
}