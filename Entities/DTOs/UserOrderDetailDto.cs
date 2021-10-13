using Core.Entites;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserOrderDetailDto : IDTo
    {
        public int ID { get; set; }
        public int YemekID { get; set; }
        public int RestoranID { get; set; }
        public int KullaniciID { get; set; }
        public String YemekAdi { get; set; }
        public String KullaniciAdi { get; set; }
        public String KullaniciSoyadi { get; set; }
        public String Telefon { get; set; }
        public String Il { get; set; }
        public String Ilce { get; set; }
        public String Adres { get; set; }
        public String RestoranAdi { get; set; }
        public bool SiparisTamamlanma { get; set; }
        public decimal Fiyat { get; set; }
        public string Resim { get; set; }
        public int Miktar { get; set; }
        public string SiparisDurum { get; set; }

    }
}
