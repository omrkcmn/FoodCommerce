using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Comment : IEntityFood
    {
        public int ID { get; set; }
        public int Puan { get; set; }
        public int RestoranId { get; set; }
        public string Yorum { get; set; }
    }
}
