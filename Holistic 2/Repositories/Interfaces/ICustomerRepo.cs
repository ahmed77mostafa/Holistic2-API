using Holistic_2.Data.DTOs;

namespace Holistic_2.Repositories.Interfaces
{
    public interface ICustomerRepo
    {
        bool AddCustomer(CustomerRequest customerDto);
        CustomerResponse GetCustomerById(int id);
    }
}
