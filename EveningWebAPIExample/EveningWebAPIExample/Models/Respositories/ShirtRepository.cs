﻿namespace EveningWebAPIExample.Models.Respositories
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
        public static List<Shirt> GetShirts()
        {
            return shirts;
        }
        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.Id == id);
        }
        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.Id == id);
        }
        public static Shirt? GetShirtByProperties(string? brand,string? gender, string?color, int? size)
        {
            return shirts.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(brand) &&
            !string.IsNullOrWhiteSpace(x.Brand) &&
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(gender) &&
            !string.IsNullOrWhiteSpace(x.Gender) &&
            x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            size.HasValue &&
            x.Size.HasValue &&
            size.Value == x.Size.Value
            );
        }
        public static void AddShirt(Shirt shirt)
        {
            int maxId = shirts.Max(x => x.Id);
            shirt.Id = maxId + 1;
            shirts.Add(shirt);
        }
        public static void UpdateShirt(Shirt shirt)
        {
            var shirtToUpdate = shirts.First(x => x.Id == shirt.Id);
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Price = shirt.Price;
            shirtToUpdate.Size = shirt.Size;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Gender = shirt.Gender;


        }
    }
}
