using System.ComponentModel.DataAnnotations;

namespace Holistic_2.Data.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public int StockQuantity { get; set; }
    }
}
