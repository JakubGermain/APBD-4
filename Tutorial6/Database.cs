public static class Database
{
    public static List<Animal> Animals = new List<Animal>
    {
        new Animal { Id = 1, Name = "Jula", Category = "Pope", Weight = 2137, ColorFurniture = "Black" },
        new Animal { Id = 2, Name = "Rose", Category = "Cat", Weight = 2, ColorFurniture = "speed blau" }
    };

    public static List<Visit> Visits = new List<Visit>
    {
        new Visit { Date = DateTime.Today, AnimalId = 1, Desc = "Checkup", Price = 100 },
        new Visit { Date = DateTime.Today.AddDays(-3), AnimalId = 2, Desc = "Vaccination", Price = 150 }
    };
}