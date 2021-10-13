using Core.Entites;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Food : IEntityFood
    {
        public int ID { get; set; }
        public string YemekAdi { get; set; }
        public string Aciklama { get; set; }
        public int RestoranID { get; set; }
        public decimal Fiyat { get; set; }
    }
}
