using System;
using System.Collections.Generic;

namespace InventoryManagementSystem
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price:C}, Quantity: {Quantity}";
        }
    }

    public class InventoryManager
    {
        private Dictionary<string, Product> products = new Dictionary<string, Product>();

        public void AddProduct(string name, decimal price, int quantity)
        {
            if (products.ContainsKey(name))
            {
                Console.WriteLine("Product already exists.");
                return;
            }
            products[name] = new Product(name,price,quantity);
            Console.WriteLine("Product added successfully.");
        }

        public void UpdateStock(string name, int change)
        {
            if (!products.ContainsKey(name))
            {
                Console.WriteLine("Product not found.");
                return;
            }
            products[name].Quantity += change;

            if (products[name].Quantity < 0)
            {
                products[name].Quantity = 0;
            }
            Console.WriteLine("Stock updated successfully.");
        }

        public void ViewStock()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products in inventory.");
                return;
            }

            foreach (var product in products.Values)
            {
                Console.WriteLine(product);
            }
        }

        public void RemoveProduct(string name)
        {
            if (!products.ContainsKey(name))
            {
                Console.WriteLine("Product not found");
                return;
            }
            products.Remove(name);
            Console.WriteLine("Product removed successfully.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InventoryManager manager = new InventoryManager();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nInventory Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. View Stock");
                Console.WriteLine("4. Remove Product");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter product name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter product price: ");
                        if(!decimal.TryParse(Console.ReadLine(), out decimal price))
                        {
                            Console.WriteLine("Invalid price format.");
                            break;
                        }

                        Console.Write("Enter product quantity: ");
                        if(!int.TryParse(Console.ReadLine(), out int quantity))
                        {
                            Console.WriteLine("Invalid quantity format.");
                            break;
                        }

                        manager.AddProduct(name, price, quantity);
                        break;


                    case "2":
                        Console.Write("Enter product name: ");
                        name = Console.ReadLine();

                        Console.Write("Enter quantity change (positive to add, negative to remove): ");
                        if(!int.TryParse(Console.ReadLine(), out int change))
                        {
                            Console.WriteLine("Invalid quantity format.");
                            break;
                        }

                        manager.UpdateStock(name, change);
                        break;
                    
                    
                    case "3":
                        manager.ViewStock();
                        break;
                    
                    
                    case "4":
                        Console.Write("Enter product name: ");
                        name = Console.ReadLine();
                        manager.RemoveProduct(name);
                        break;
                    
                    
                    case "5":
                        running = false;
                        break;
                    
                    
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}