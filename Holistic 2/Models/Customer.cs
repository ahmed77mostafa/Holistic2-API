using System.ComponentModel.DataAnnotations;

namespace Holistic_2.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Phone]
        public string Contact { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public List<Order> Orders { get; set; }
        public int? ShoppingCartId {get; set;}
        public ShoppingCart ShoppingCart { get; set; }
    }
}
