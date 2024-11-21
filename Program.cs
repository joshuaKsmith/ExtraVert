
List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Peony",
        LightNeeds = 2,
        AskingPrice = 10.00M,
        City = "Hopkinsville",
        ZIP = "42240",
        Sold = false
    },
    new Plant()
    {
        Species = "Rose",
        LightNeeds = 4,
        AskingPrice = 12.00M,
        City = "Hopkinsville",
        ZIP = "42240",
        Sold = true
    },
    new Plant()
    {
        Species = "Daisy",
        LightNeeds = 1,
        AskingPrice = 15.00M,
        City = "Bowling Green",
        ZIP = "42101",
        Sold = false
    },
    new Plant()
    {
        Species = "Tulip",
        LightNeeds = 1,
        AskingPrice = 10.00M,
        City = "Bowling Green",
        ZIP = "42101",
        Sold = false
    },
    new Plant()
    {
        Species = "Petunia",
        LightNeeds = 2,
        AskingPrice = 12.00M,
        City = "Bowling Green",
        ZIP = "42101",
        Sold = false
    },
};

Console.WriteLine(@"Welcome to ExtraVert FlowerShop
AKA that one place");

// User Menu
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"-- Choose an option:
        0. Exit
        1. Display all plants
        2. Post a plant to be adopted
        3. Adopt a plant
        4. Delist a plant"
    );

    choice = Console.ReadLine();
    Console.Clear();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListPlants();
    }
    else if (choice == "2")
    {
        PostPlantForAdoption();
    }
    else if (choice == "3")
    {
        AdoptPlant();
    }
    else if (choice == "4")
    {
        DelistPlant();
    }
    else 
    {
        Console.WriteLine("Invalid Input!");
    }
}   

void ListPlants()
{
    Console.WriteLine("Plants:");
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for {plants[i].AskingPrice} dollars");
    }
}

void PostPlantForAdoption()
{
    // Ask for species
    Console.WriteLine("-- Please enter the species of plant you are posting for adoption:");
    string speciesResponse = Console.ReadLine();

    // Ask for light needs
    Console.Clear();
    Console.WriteLine(@"We measure the Light Needs of a plant on a scale from 1 to 5,
where a plant rated 1 needs the least amount of light and a plant rated 5 needs the most.
-- Please enter a Light Needs number from 1 to 5 for the plant you are posting for adoption:"
    );
    int lightResponse = int.Parse(Console.ReadLine().Trim());

    // Ask for asking price
    Console.Clear();
    Console.WriteLine("-- Please enter the asking price of the plant you are posting for adoption:");
    decimal priceResponse = decimal.Parse(Console.ReadLine().Trim());

    // Ask for city
    Console.Clear();
    Console.WriteLine("-- Please enter the City the plant you are posting for adoption is available in:");
    string cityResponse = Console.ReadLine();

    // Ask for ZIP
    Console.Clear();
    Console.WriteLine("-- Please enter the ZIP code the plant you are posting for adoption is available in:");
    string zipResponse = Console.ReadLine();

    // Create and add new object to Plants list
    Plant plantToPost = new Plant()
    {
        Species = speciesResponse,
        LightNeeds = lightResponse,
        AskingPrice = priceResponse,
        City = cityResponse,
        ZIP = zipResponse,
        Sold = false
    };
    plants.Add(plantToPost);
    Console.Clear();
    Console.WriteLine($"New {plantToPost.Species} posted for adoption!");
}

void AdoptPlant()
{
    // List available plants filtered by Sold == false
    Console.WriteLine("Please select a plant to adopt");
    for (int i = 0; i < plants.Count; i++)
    {
        if (plants[i].Sold == false)
        {
            Console.WriteLine($"{i+1}. {plants[i].Species}, available for {plants[i].AskingPrice} in {plants[i].City}.");
        }
    }

    // Take user input and store selected index
    int adoptChoice = int.Parse(Console.ReadLine().Trim()) - 1;

    // Change Sold property of selected plant to true
    plants[adoptChoice].Sold = true;
    Console.Clear();
    Console.WriteLine($"{plants[adoptChoice].Species} adopted!");
}

void DelistPlant()
{
    // List all plants
    Console.WriteLine("Please select a plant to delist");
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City}.");
    }

    // Take user input and store selected index
    int delistChoice = int.Parse(Console.ReadLine().Trim()) - 1;

    // Remove selected plant from plants list with RemoveAt method
    plants.RemoveAt(delistChoice);
    Console.Clear();
    Console.WriteLine($"{plants[delistChoice].Species} delisted!");
}