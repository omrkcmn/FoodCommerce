using Core.Entites;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class User : IEntityFood
    {
        public int ID { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciSoyadi { get; set; }
        public string Adres { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Telefon { get; set; }
        
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        //YemekSepeti Column
        public int RestoranId { get; set; }
    }
}
