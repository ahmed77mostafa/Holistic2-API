using System.ComponentModel.DataAnnotations;

namespace Holistic_2.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        [Required]
        public int NumOfItems { get; set; }
        public Customer Customer { get; set; }
    }
}
