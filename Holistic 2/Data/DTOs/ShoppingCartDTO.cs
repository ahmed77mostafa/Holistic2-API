using Holistic_2.Models;
using System.ComponentModel.DataAnnotations;

namespace Holistic_2.Data.DTOs
{
    public class ShoppingCartDTO
    {
        public int Id { get; set; }
        [Required]
        public int NumOfItems { get; set; }
    }
}
