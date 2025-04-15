using Holistic_2.Models;
using System.ComponentModel.DataAnnotations;

namespace Holistic_2.Data.DTOs
{
    public class OrderRequest
    {
        [Required]
        public int TotalPrice { get; set; }
        public int? CustomerId { get; set; }
        public List<ProductDto> Products { get; set; }
    }
    public class OrderWithCustomer
    {
        [Required]
        public int TotalPrice { get; set; }
        public List<ProductDto> Products { get; set; }
    }
    public class OrderWithProduct
    {
        [Required]
        public int TotalPrice { get; set; }
        public List<int> ProductId { get; set; }
    }
    public class OrderResponse
    {
        public int Id { get; set; }
        [Required]
        public int TotalPrice { get; set; }
        public CustomerOrderResponse customer { get; set; }
        public int? CustomerId { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
