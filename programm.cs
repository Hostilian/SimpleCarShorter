static void Main(string[] args)
{
    string filePath = @"C:\Users\Hostilian\OneDrive\Documents\GitHub\SimpleCarShorter\data.csv\all-vehicles-model.csv";
    
    try
    {
        if (File.Exists(filePath))
        {
            LoadCarsFromFile(filePath);
            DisplayMenu();
        }
        else
        {
            Console.WriteLine("Error: The file path specified does not exist.");
        }
    }
    catch (IOException ex)
    {
        Console.WriteLine($"Error reading the file: {ex.Message}");
    }
}

static void LoadCarsFromFile(string filePath)
{
    using (StreamReader reader = new StreamReader(filePath))
    {
        string header = reader.ReadLine(); // Skip header row

        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] parts = line.Split(';'); // Assuming the new CSV format uses semicolon as the delimiter

            if (parts.Length >= 4)
            {
                string manufacturer = parts[0].Trim();
                string model = parts[1].Trim();
                if (!int.TryParse(parts[64].Trim(), out int year))
                {
                    year = 0; // default or error value
                }
                string color = "Unknown"; // Default color as it's not available in the CSV

                Car car = new Car(manufacturer, model, year, color);
                cars.Add(car);
            }
        }
    }
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

    List<Car> filteredCars = cars.Where(c => c.Manufacturer.Equals(manufacturer, StringComparison.OrdinalIgnoreCase)).ToList();

    Console.WriteLine($"Cars by {manufacturer}:");
    if (filteredCars.Any())
    {
        foreach (Car car in filteredCars)
        {
            Console.WriteLine(car);
        }
    }
    else
    {
        Console.WriteLine("No cars found for this manufacturer.");
    }
}

static void FilterByModel()
{
    Console.Write("Enter model: ");
    string model = Console.ReadLine().Trim();

    List<Car> filteredCars = cars.Where(c => c.Model.Equals(model, StringComparison.OrdinalIgnoreCase)).ToList();

    Console.WriteLine($"Cars of model {model}:");
    if (filteredCars.Any())
    {
        foreach (Car car in filteredCars)
        {
            Console.WriteLine(car);
        }
    }
    else
    {
        Console.WriteLine("No cars found for this model.");
    }
}

static void FilterByYear()
{
    Console.Write("Enter year: ");
    if (int.TryParse(Console.ReadLine().Trim(), out int year))
    {
        List<Car> filteredCars = cars.Where(c => c.Year == year).ToList();

        Console.WriteLine($"Cars from {year}:");
        if (filteredCars.Any())
        {
            foreach (Car car in filteredCars)
            {
                Console.WriteLine(car);
            }
        }
        else
        {
            Console.WriteLine("No cars found for this year.");
        }
    }
    else
    {
        Console.WriteLine("Invalid year input.");
    }
}

static void FilterByColor()
{
    Console.Write("Enter color: ");
    string color = Console.ReadLine().Trim();

    List<Car> filteredCars = cars.Where(c => c.Color.Equals(color, StringComparison.OrdinalIgnoreCase)).ToList();

    Console.WriteLine($"Cars in {color}:");
    if (filteredCars.Any())
    {
        foreach (Car car in filteredCars)
        {
            Console.WriteLine(car);
        }
    }
    else
    {
        Console.WriteLine("No cars found for this color.");
    }
}
