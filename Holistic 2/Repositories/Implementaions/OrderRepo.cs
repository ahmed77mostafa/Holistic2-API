using Holistic_2.Data;
using Holistic_2.Data.DTOs;
using Holistic_2.Models;
using Holistic_2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Holistic_2.Repositories.Implementaions
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext _context;

        public OrderRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool AddOrder(OrderRequest orderRequest)
        {
            Order order = new Order
            {
                TotalPrice = orderRequest.TotalPrice,
                Products = orderRequest.Products.Select(p => new Product
                {
                    Name = p.Name,
                    Description = p.Description,
                    StockQuantity = p.StockQuantity,
                }).ToList(),
                CustomerId = orderRequest.CustomerId,
            };
            _context.Orders.Add(order);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteOrder(int Id)
        {
            var order = _context.Orders
                .Include(p => p.Products)
                .Include(c => c.customer)
                .ThenInclude(s => s.ShoppingCart)
                .FirstOrDefault(i =>i.Id == Id);
            if(order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<OrderResponse> GetOrders()
        {
            var orders = _context.Orders
                .Include(p => p.Products)
                .Include(c => c.customer)
                .ThenInclude(s => s.ShoppingCart)
                .Select(o => new OrderResponse
                {
                    Id = o.Id,
                    TotalPrice = o.TotalPrice,
                    Products = o.Products.Select(p => new ProductDto
                    {
                        Name = p.Name,
                        Description = p.Description,
                        StockQuantity = p.StockQuantity,
                    }).ToList(),
                    CustomerId = o.CustomerId,
                    customer = new CustomerOrderResponse
                    {
                        Id = o.customer.Id,
                        Name = o.customer.Name,
                        Email = o.customer.Email,
                        Contact = o.customer.Contact,
                        ShoppingCartId = o.customer.ShoppingCartId,
                        ShoppingCart = new ShoppingCartDTO
                        {
                            Id = o.customer.ShoppingCart.Id,
                            NumOfItems = o.customer.ShoppingCart.NumOfItems
                        },
                    }
                }).ToList();

            if(orders.Any())
                return orders;
            return null;
        }

        public bool UpdateOrder(int Id, OrderWithProduct orderDto)
        {
            var order = _context.Orders
                .Include(p => p.Products)
                .Include(c => c.customer)
                .ThenInclude(s => s.ShoppingCart)
                .FirstOrDefault(i => i.Id == Id);

            List<Product> products = new List<Product>();
            foreach(var index in orderDto.ProductId)
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == index);
                if(product != null)
                {
                    products.Add(product);
                }
                else
                {
                    throw new Exception($"Can't find product with ID {index}");
                }
            }
            if (order == null)
                return false;



            order.TotalPrice = orderDto.TotalPrice;
            order.Products = products;
            _context.Orders.Update(order);
            _context.SaveChanges();
            return true;
        }
    }
}
