using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OrderDetailDto : IDTo
    {
        public string FoodName { get; set; }
        public string RestourantName { get; set; }
        public string Adress { get; set; }
        public string UserName { get; set; }
        public string UserLastname { get; set; }
        public string ImagePath { get; set; }
    }
}