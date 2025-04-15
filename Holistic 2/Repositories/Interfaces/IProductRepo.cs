using Holistic_2.Data.DTOs;

namespace Holistic_2.Repositories.Interfaces
{
    public interface IProductRepo
    {
        bool AddProduct(ProductDto productDto);
    }
}
