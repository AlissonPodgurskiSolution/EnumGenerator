using EnumGeneratorDemoApp.Enums;
using System;

namespace EnumGeneratorDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Status = OrderStatus.Pending
            };

            var user = new User
            {
                Id = Guid.NewGuid(),
                Role = UserRole.Admin
            };

            Console.WriteLine($"Order ID: {order.Id}, Status: {order.Status}");
            Console.WriteLine($"User ID: {user.Id}, Role: {user.Role}");
        }
    }

    public class Order
    {
        public Guid Id { get; set; }
        public OrderStatus Status { get; set; }
    }

    public class User
    {
        public Guid Id { get; set; }
        public UserRole Role { get; set; }
    }
}
