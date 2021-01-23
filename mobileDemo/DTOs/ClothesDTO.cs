using System;
using System.Collections.Generic;
using System.Text;

namespace mobileDemo.DTOs
{
    public class ClothesDTO
    {
        public ClothesItemDTO[] ClothesItems { get; set; } = new ClothesItemDTO[0];
        public string ClothesSource { get; set; }
        public string ClothesTitle { get; set; }
        public long ClothesId { get; set; }
    }
}
