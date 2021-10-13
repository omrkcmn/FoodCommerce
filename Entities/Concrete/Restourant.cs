using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Restourant : IEntityFood
    {
        public int ID { get; set; }
        public string RestoranAdi { get; set; }
        public string RestoranAdresi { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Mahalle { get; set; }
    }
}
