using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            AddOrders();
        }

        private void AddOrders()
        {
            var context = ObjectContextFactory.GetContext("connectionString");

            var customerRepository = new CustomerRepository(context);
            var repository = new GenericRepository(context);

            var c = customerRepository.FindByName("John", "Doe");

            var winXP = repository.Single<Product>(x => x.Name == "Windows XP Professional");
            var winSeven = repository.Single<Product>(x => x.Name == "Windows Seven Professional");

            var o = new Order
            {
                OrderDate = DateTime.Now,
                Purchaser = c,
                OrderLines = new List<OrderLine>
        {
            new OrderLine { Price = 200, Product = winXP, Quantity = 1},
            new OrderLine { Price = 699.99, Product = winSeven, Quantity = 5 }
        }
            };

            repository.Add<Order>(o);
            repository.SaveChanges();
        }
    }
}
