using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class FoodDetailDto : IDTo
    {
        public int YemekID { get; set; }
        public int RestoranID { get; set; }
        public string YemekAdi { get; set; }
        public string RestoranAdi { get; set; }
        public string YemekResim { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
    }
}