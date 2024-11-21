
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

ListPlants();

void ListPlants()
{
    Console.WriteLine("Plants:");
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
    }
}