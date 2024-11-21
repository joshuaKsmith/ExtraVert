
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
    Console.WriteLine(@"Choose an option:
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
        throw new NotImplementedException("Post a plant to be adopted");
    }
    else if (choice == "3")
    {
        throw new NotImplementedException("Adopt a plant");
    }
    else if (choice == "4")
    {
        throw new NotImplementedException("Delist a plant");
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
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
    }
}