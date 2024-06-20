using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static List<Car> cars = new List<Car>();

    static void Main(string[] args)
    {
        LoadCarsFromFile("all-vehicles-model.csv");
        DisplayMenu();
    }

    static void DisplayMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Car Filter Database");
            Console.WriteLine("1. Display Entire Database");
            Console.WriteLine("2. Filter by Manufacturer");
            Console.WriteLine("3. Filter by Model");
            Console.WriteLine("4. Filter by Year");
            Console.WriteLine("5. Filter by Color");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayAllCars();
                    break;
                case "2":
                    FilterByManufacturer();
                    break;
                case "3":
                    FilterByModel();
                    break;
                case "4":
                    FilterByYear();
                    break;
                case "5":
                    FilterByColor();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }

    static void LoadCarsFromFile(string filename)
    {
        using (StreamReader reader = new StreamReader(filename))
        {
            string header = reader.ReadLine(); // Skip header row

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(',');

                string manufacturer = parts[0].Trim();
                string model = parts[1].Trim();
                int year = int.Parse(parts[2].Trim());
                string color = parts[3].Trim();

                Car car = new Car(manufacturer, model, year, color);
                cars.Add(car);
            }
        }
    }

    static void DisplayAllCars()
    {
        Console.WriteLine("All Cars:");
        foreach (Car car in cars)
        {
            Console.WriteLine(car);
        }
    }

    static void FilterByManufacturer()
    {
        Console.Write("Enter manufacturer: ");
        string manufacturer = Console.ReadLine().Trim();

        List<Car> filteredCars = cars.Where(c => c.Manufacturer == manufacturer).ToList();

        Console.WriteLine($"Cars by {manufacturer}:");
        foreach (Car car in filteredCars)
        {
            Console.WriteLine(car);
        }
    }

    static void FilterByModel()
    {
        Console.Write("Enter model: ");
        string model = Console.ReadLine().Trim();

        List<Car> filteredCars = cars.Where(c => c.Model == model).ToList();

        Console.WriteLine($"Cars of model {model}:");
        foreach (Car car in filteredCars)
        {
            Console.WriteLine(car);
        }
    }

    static void FilterByYear()
    {
        Console.Write("Enter year: ");
        int year = int.Parse(Console.ReadLine().Trim());

        List<Car> filteredCars = cars.Where(c => c.Year == year).ToList();

        Console.WriteLine($"Cars from {year}:");
        foreach (Car car in filteredCars)
        {
            Console.WriteLine(car);
        }
    }

    static void FilterByColor()
    {
        Console.Write("Enter color: ");
        string color = Console.ReadLine().Trim();

        List<Car> filteredCars = cars.Where(c => c.Color == color).ToList();

        Console.WriteLine($"Cars in {color}:");
        foreach (Car car in filteredCars)
        {
            Console.WriteLine(car);
        }
    }
}

class Car
{
    public string Manufacturer { get; }
    public string Model { get; }
    public int Year { get; }
    public string Color { get; }

    public Car(string manufacturer, string model, int year, string color)
    {
        Manufacturer = manufacturer;
        Model = model;
        Year = year;
        Color = color;
    }

    public override string ToString()
    {
        return $"{Manufacturer} {Model} ({Year}) - {Color}";
    }
}
