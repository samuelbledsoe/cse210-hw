using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("T-shirt", "TS100", 15.00m, 2));
        order1.AddProduct(new Product("Hat", "HT200", 10.00m, 1));

        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Jacket", "JK300", 50.00m, 1));
        order2.AddProduct(new Product("Gloves", "GL400", 12.00m, 2));

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine("PACKING LABEL:");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine("SHIPPING LABEL:");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"TOTAL PRICE: ${order.GetTotalCost():0.00}");
            Console.WriteLine(new string('-', 40));
        }
    }
}
