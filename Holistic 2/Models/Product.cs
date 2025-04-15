using System.ComponentModel.DataAnnotations;

namespace Holistic_2.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        public List<Order> Orders { get; set; }
    }
}
