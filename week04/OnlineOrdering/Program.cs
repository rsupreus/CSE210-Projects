using System;

class Program
{
    static void Main(string[] args)
    {
        // First order: customer lives in the USA.
        Address address1 = new Address(
            "145 West Main Street",
            "St. George",
            "Utah",
            "USA"
        );

        Customer customer1 = new Customer(
            "Maria Johnson",
            address1
        );

        Order order1 = new Order(customer1);

        order1.AddProduct(
            new Product("Wireless Mouse", "WM-100", 24.99, 2)
        );

        order1.AddProduct(
            new Product("Mechanical Keyboard", "MK-205", 79.99, 1)
        );

        order1.AddProduct(
            new Product("USB-C Cable", "UC-310", 12.50, 3)
        );

        // Second order: customer lives outside the USA.
        Address address2 = new Address(
            "22 Maple Avenue",
            "Toronto",
            "Ontario",
            "Canada"
        );

        Customer customer2 = new Customer(
            "Daniel Williams",
            address2
        );

        Order order2 = new Order(customer2);

        order2.AddProduct(
            new Product("Laptop Stand", "LS-450", 39.99, 1)
        );

        order2.AddProduct(
            new Product("Webcam", "WC-520", 54.95, 2)
        );

        DisplayOrder("ORDER 1", order1);
        DisplayOrder("ORDER 2", order2);
    }

    static void DisplayOrder(string heading, Order order)
    {
        Console.WriteLine("================================");
        Console.WriteLine(heading);
        Console.WriteLine("================================");

        Console.WriteLine("\nPacking Label:");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine(
            $"\nTotal Price: ${order.CalculateTotalCost():F2}"
        );

        Console.WriteLine();
    }
}