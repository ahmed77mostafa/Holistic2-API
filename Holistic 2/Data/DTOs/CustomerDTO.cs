using Holistic_2.Models;
using System.ComponentModel.DataAnnotations;

namespace Holistic_2.Data.DTOs
{
    public class CustomerRequest
    {
        public string Name { get; set; }
        [Phone]
        public string Contact { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public List<OrderWithCustomer> Orders { get; set; }
        public ShoppingCartDTO ShoppingCart { get; set; }
    }
    public class CustomerResponse
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Phone]
        public string Contact { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public List<OrderWithCustomer> Orders { get; set; }
        public int? ShoppingCartId { get; set; }
        public ShoppingCartDTO ShoppingCart { get; set; }
    }
    public class CustomerOrderResponse
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Phone]
        public string Contact { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int? ShoppingCartId { get; set; }
        public ShoppingCartDTO ShoppingCart { get; set; }
    }
}
