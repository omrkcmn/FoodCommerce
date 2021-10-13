using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Cart: IEntityFood
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }
        public bool Tamamlandimi { get; set; }
    }
}
