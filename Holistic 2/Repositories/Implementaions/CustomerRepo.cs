using Holistic_2.Data;
using Holistic_2.Data.DTOs;
using Holistic_2.Models;
using Holistic_2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Holistic_2.Repositories.Implementaions
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly AppDbContext _context;

        public CustomerRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool AddCustomer(CustomerRequest customerDto)
        {
            Customer customer = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                Contact = customerDto.Contact,
                ShoppingCart = new ShoppingCart
                {
                    NumOfItems = customerDto.ShoppingCart.NumOfItems
                },
                Orders = customerDto.Orders.Select(s => new Order
                {
                    TotalPrice = s.TotalPrice,
                    Products = s.Products.Select(p => new Product
                    {
                        Name = p.Name,
                        Description = p.Description,
                        StockQuantity = p.StockQuantity,
                    }).ToList(),
                }).ToList(),
            };
            _context.Customers.Add(customer);
            return _context.SaveChanges() > 0;
        }

        public CustomerResponse GetCustomerById(int id)
        {
            var Customer = _context.Customers
                .Include(s => s.ShoppingCart)
                .Include(o => o.Orders)
                .ThenInclude(p => p.Products)
                .FirstOrDefault(c => c.Id == id);

            if (Customer != null)
            {
                CustomerResponse response = new CustomerResponse
                {
                    Id = Customer.Id,
                    Name = Customer.Name,
                    Email = Customer.Email,
                    Contact = Customer.Contact,
                    ShoppingCartId = Customer.ShoppingCartId,
                    ShoppingCart = new ShoppingCartDTO
                    {
                        Id = Customer.ShoppingCart.Id,
                        NumOfItems = Customer.ShoppingCart.NumOfItems,
                    },
                    Orders = Customer.Orders.Select(o => new OrderWithCustomer
                    {
                        TotalPrice = o.TotalPrice,
                        Products = o.Products.Select(p => new ProductDto
                        {
                            Name = p.Name,
                            Description = p.Description,
                            StockQuantity = p.StockQuantity,
                        }).ToList(),
                    }).ToList(),
                };
                return response;
            }
            return null;
        }
    }
}
