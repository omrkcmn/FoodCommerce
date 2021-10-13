using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CommentDetailDto:IDTo
    {
        public int ID { get; set; }
        public int Puan { get; set; }
        public int RestoranId { get; set; }
        public string Yorum { get; set; }
        public string RestoranAdi { get; set; }
    }
}
