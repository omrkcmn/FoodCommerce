using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CartDetailDto:IDTo
    {
        public int Id { get; set; }
        public int YemekID { get; set; }
        public int RestoranID { get; set; }
        public string YemekAdi { get; set; }
        public string RestoranAdi { get; set; }
        public string YemekResim { get; set; }
        public bool Tamamlandimi { get; set; }
        public int SiparisId { get; set; }
        public int UserId { get; set; }
        public decimal Fiyat { get; set; }
        public int Miktar { get; set; }
    }
}
