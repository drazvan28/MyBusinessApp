using System;
using System.Collections.Generic;
using System.IO;
using MyBusinessApp;

namespace MyBusinessApp
{
    class Program
    {
        static List<BusinessEntity> entities = new List<BusinessEntity>();

        static void Main(string[] args)
        {
            string filePath = "entities.csv";
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Add New Entity");
                Console.WriteLine("2. Display All Entities");
                Console.WriteLine("3. Update an Entity");
                Console.WriteLine("4. Delete an Entity");
                Console.WriteLine("5. Save Entities to CSV");
                Console.WriteLine("6. Load Entities from CSV");
                Console.WriteLine("7. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEntity();
                        break;
                    case "2":
                        DisplayEntities();
                        break;
                    case "3":
                        UpdateEntity();
                        break;
                    case "4":
                        DeleteEntity();
                        break;
                    case "5":
                        SaveToCsv(filePath);
                        break;
                    case "6":
                        LoadFromCsv(filePath);
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void AddEntity()
        {
            Console.WriteLine("Choose Entity Type: 1. Customer, 2. Product");
            string type = Console.ReadLine();

            switch (type)
            {
                case "1":
                    Console.Write("Enter ID: ");
                    int custId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    string custName = Console.ReadLine();
                    Console.Write("Enter Email: ");
                    string email = Console.ReadLine();
                    entities.Add(new Customer(custId, custName, email));
                    break;
                case "2":
                    Console.Write("Enter ID: ");
                    int prodId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    string prodName = Console.ReadLine();
                    Console.Write("Enter Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    entities.Add(new Product(prodId, prodName, price));
                    break;
                default:
                    Console.WriteLine("Invalid type.");
                    break;
            }
        }

        static void DisplayEntities()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                Console.WriteLine(entities[i].ToString());
            }
        }

        static void UpdateEntity()
        {
            Console.Write("Enter the index of the entity to update: ");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < entities.Count)
            {
                Console.WriteLine("Choose Entity Type: 1. Customer, 2. Product");
                string type = Console.ReadLine();

                switch (type)
                {
                    case "1":
                        Console.Write("Enter New Name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter New Email: ");
                        string newEmail = Console.ReadLine();
                        if (entities[index] is Customer)
                        {
                            entities[index].Name = newName;
                            ((Customer)entities[index]).Email = newEmail;
                        }
                        break;

                    case "2":
                        Console.Write("Enter New Name: ");
                        string prodName = Console.ReadLine();
                        Console.Write("Enter New Price: ");
                        decimal newPrice = decimal.Parse(Console.ReadLine());
                        if (entities[index] is Product)
                        {
                            entities[index].Name = prodName;
                            ((Product)entities[index]).Price = newPrice;
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid type.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }

        static void DeleteEntity()
        {
            Console.Write("Enter the index of the entity to delete: ");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < entities.Count)
            {
                Console.Write("Are you sure you want to delete this entity? (yes/no): ");
                string confirmation = Console.ReadLine();

                if (confirmation.ToLower() == "yes")
                {
                    entities.RemoveAt(index);
                    Console.WriteLine("Entity deleted.");
                }
                else
                {
                    Console.WriteLine("Deletion canceled.");
                }
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }

        static void SaveToCsv(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    for (int i = 0; i < entities.Count; i++)
                    {
                        writer.WriteLine(entities[i].ToString());
                    }
                }
                Console.WriteLine("Entities saved to CSV.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving to CSV: " + ex.Message);
            }
        }

        static void LoadFromCsv(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    entities.Clear();
                    string[] lines = File.ReadAllLines(filePath);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string[] data = lines[i].Split(',');
                        // Implement logic to parse data into appropriate objects
                        // Based on specific format in ToString()
                    }
                    Console.WriteLine("Entities loaded from CSV.");
                }
                else
                {
                    Console.WriteLine("CSV file not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading from CSV: " + ex.Message);
            }
        }
    }
}