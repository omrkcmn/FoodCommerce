using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class FoodImage : IEntityFood
    {
        public int ID { get; set; }
        public int YemekID { get; set; }
        public string ResimPath { get; set; }
        public DateTime Date { get; set; }
    }
}
