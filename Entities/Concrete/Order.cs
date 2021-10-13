using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Order : IEntityFood
    {
        public int ID { get; set; }
        public int RestoranID { get; set; }
        public int YemekID { get; set; }
        public int KullaniciID { get; set; }
        public bool Tamamlandimi { get; set; }
        public int Miktar { get; set; }
        public string SiparisDurum { get; set; }
    }
}
