using MvcRehber.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcRehber.Models.KisiModel
{
    public class KisiEkleViewModel
    {
        //bu modelde bizim hem kişi hem şehir entity modellerini tutmamız gerekiyor. bunu da kişi ve şehir türünde propertyler oluşturarak sağlıyoruz
        public Kisi Kisi { get; set; }
        public List<Sehir> Sehirler { get; set; }
        public List<TBLUserInfo> TBLUserInfo { get; set; }
    }
}