
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
        Sold = false,
        AvailableUntil = new DateTime(2025, 10, 10)
    },
};

// Set plant of the day index
Random random = new Random();
bool validIndex = false;
int indexPOTD = 0;
while (!validIndex)
{
    int testIndex = random.Next(0, plants.Count);
    if (plants[testIndex].Sold == false)
    {
        indexPOTD = testIndex;
        validIndex = true;
    }
}

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
        4. Delist a plant
        5. Plant of the day
        6. Search plants by Light Needs
        7. Statistics"
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
    else if (choice == "5")
    {
        ShowPlantOfTheDay();
    }
    else if (choice == "6")
    {
        SearchPlantsByLightNeeds();
    }
    else if (choice == "7")
    {
        AppStatistics();
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
    string speciesRes = Console.ReadLine();

    // Ask for light needs
    Console.Clear();
    Console.WriteLine(@"We measure the Light Needs of a plant on a scale from 1 to 5,
where a plant rated 1 needs the least amount of light and a plant rated 5 needs the most.
-- Please enter a Light Needs number from 1 to 5 for the plant you are posting for adoption:"
    );
    int lightRes = int.Parse(Console.ReadLine().Trim());

    // Ask for asking price
    Console.Clear();
    Console.WriteLine("-- Please enter the asking price of the plant you are posting for adoption:");
    decimal priceRes = decimal.Parse(Console.ReadLine().Trim());

    // Ask for city
    Console.Clear();
    Console.WriteLine("-- Please enter the City the plant you are posting for adoption is available in:");
    string cityRes = Console.ReadLine();

    // Ask for ZIP
    Console.Clear();
    Console.WriteLine($"-- Please enter your {cityRes} ZIP code:");
    string zipRes = Console.ReadLine();

    // Ask for Year of listing expiry
    Console.Clear();
    Console.WriteLine("-- Please enter the Year that this listing will expire:");
    int yearRes = int.Parse(Console.ReadLine().Trim());
    
    // Ask for Month of listing expiry
    Console.Clear();
    Console.WriteLine($"-- Please enter the Month (1-12) in {yearRes} that this listing will expire:");
    int monthRes = int.Parse(Console.ReadLine().Trim());

    // Ask for Day of listing expiry
    Console.Clear();
    Console.WriteLine("-- Please enter the Day of the month that this listing will expire:");
    int dayRes = int.Parse(Console.ReadLine().Trim());

    // Create and add new object to Plants list
    DateTime dateRes = new DateTime(yearRes, monthRes, dayRes);
    Plant plantToPost = new Plant()
    {
        Species = speciesRes,
        LightNeeds = lightRes,
        AskingPrice = priceRes,
        City = cityRes,
        ZIP = zipRes,
        Sold = false,
        AvailableUntil = dateRes,
    };
    plants.Add(plantToPost);
    Console.Clear();
    Console.WriteLine($"New {plantToPost.Species} posted for adoption!");
}

void AdoptPlant()
{
    // NEED TO VALIDATE THIS INPUT
    // List available plants filtered by Sold == false
    Console.WriteLine("Please select a plant to adopt");
    for (int i = 0; i < plants.Count; i++)
    {
        if (plants[i].Sold == false && plants[i].AvailableUntil > DateTime.Now)
        {
            Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for {plants[i].AskingPrice} dollar{(plants[i].AskingPrice == 1 ? "" : "s")}");
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
    // NEED TO VALIDATE THIS INPUT
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

void ShowPlantOfTheDay()
{
    Console.Clear();
    Console.WriteLine($"{plants[indexPOTD].Species} {(plants[indexPOTD].Sold ? "was sold" : "is available")} for {plants[indexPOTD].AskingPrice} in {plants[indexPOTD].City}!");
}

void SearchPlantsByLightNeeds()
{
    // NEED TO VALIDATE THIS INPUT
    // Take user input and store selection between 1 and 5
    Console.WriteLine("Please select a number between 1 and 5");
    int lightFilterNum = int.Parse(Console.ReadLine());

    // Filter into new list of plants with lighting needs at or below the user selection
    List<Plant> filteredPlants = new List<Plant>();
    foreach (Plant plant in plants)
    {
        if (plant.LightNeeds <= lightFilterNum)
        {
            filteredPlants.Add(plant);
        }
    }

    // Display the new list of plants filtered by lightning needs
    Console.Clear();
    Console.WriteLine("Plants within your selected range of Light Needs:");
    for (int i = 0; i < filteredPlants.Count; i++)
    {
        Console.WriteLine($"{plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for {plants[i].AskingPrice} dollars");
    }    
}

void AppStatistics()
{
    // lowest priced plant
    string cheapPlant = "";

    // number of plants available to adopt
    int availablePlants = 0;

    // plant with highest light needs
    string needyPlant = "";

    // average light needs
    decimal avgLight = 0.0M;

    // percentage of plants adopted
    int adoptedPercentage = 0;

    // Display statistics
    Console.Clear();
    Console.WriteLine("STATS");
    Console.WriteLine($"Lowest price plant name:   {cheapPlant}");
    Console.WriteLine($"Number of Plants Available:   {availablePlants}");
    Console.WriteLine($"Name of plant with highest light needs:   {needyPlant}");
    Console.WriteLine($"Average light needs:   {avgLight}");
    Console.WriteLine($"Percentage of plants adopted:   {adoptedPercentage}");
}