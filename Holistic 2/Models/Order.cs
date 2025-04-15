using System.ComponentModel.DataAnnotations;

namespace Holistic_2.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public int TotalPrice {  get; set; }
        public Customer customer { get; set; }
        public int? CustomerId { get; set; }
        public List<Product> Products { get; set; }
    }
}
