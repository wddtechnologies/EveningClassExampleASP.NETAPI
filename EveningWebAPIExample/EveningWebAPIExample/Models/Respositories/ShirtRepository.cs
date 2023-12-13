namespace EveningWebAPIExample.Models.Respositories
{
    public class ShirtRepository
    {
        private static List<Shirt> shirts = new List<Shirt>() 
        {
        new Shirt{Id = 1, Brand ="Nike", Color = "Blue", Gender = "Men", Price = 30, Size = 10},
        new Shirt{Id = 2, Brand ="Addias", Color = "Green", Gender = "Men", Price = 40, Size = 8},
        new Shirt{Id = 3, Brand ="Nike", Color = "Blue", Gender = "Women", Price = 30, Size = 5},
        new Shirt{Id = 4, Brand ="Upper", Color = "Green", Gender = "Women", Price = 40, Size = 6},
        new Shirt{Id = 5, Brand ="Lower", Color = "Blue", Gender = "Women", Price = 10, Size = 2}

        };
        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.Id == id);
        }
        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.Id == id);
        }
    }
}
