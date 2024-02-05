using API.DTOs;

namespace API.Models.Shirt.Repositories
{
    public static class ShirtRepository
    {
        private static List<ShirtDto> shirts = new List<ShirtDto>()
        {
               new ShirtDto { Id = 1, Name = "Blue shirt",Brand = "Samsung", Color = "Blue", Gender = "Men", Price = 10, Size = new[] { "S", "M", "L", "XL" } },
    new ShirtDto { Id = 2, Name = "Red shirt",Brand = "Nokia", Color = "Red", Gender = "Men", Price = 30, Size = new[] { "S", "M", "L", "XL" } },
    new ShirtDto { Id = 3, Name = "Yellow shirt",Brand = "LV", Color = "Yellow", Gender = "Women", Price = 40, Size = new[] { "XS", "S", "M", "L", "XL" } },
    new ShirtDto { Id = 4, Name = "White shirt",Brand = "Gucci", Color = "White", Gender = "Women", Price = 60, Size = new[] { "XS", "S", "M", "L", "XL" } },
    new ShirtDto { Id = 5, Name = "Green shirt",Brand = "Channel", Color = "Green", Gender = "Women", Price = 80, Size = new[] { "XS", "S", "M", "L", "XL" } },
    new ShirtDto { Id = 6,Name = "Pink shirt", Brand = "Xiaomi", Color = "Pink", Gender = "Women", Price = 100, Size = new[] { "XS", "S", "M", "L", "XL" } },
    new ShirtDto { Id = 7, Name = "Purple shirt",Brand = "MSI", Color = "Purple", Gender = "Women", Price = 60, Size = new[] { "XS", "S", "M", "L", "XL" } },
    new ShirtDto { Id = 8, Name = "Orange shirt",Brand = "Alien", Color = "Orange", Gender = "Women", Price = 50, Size = new[] { "XS", "S", "M", "L", "XL" } },
    new ShirtDto { Id = 9,Name = "Mint shirt", Brand = "Nike", Color = "Mint", Gender = "Women", Price = 30, Size = new[] { "XS", "S", "M", "L", "XL" } },
    new ShirtDto { Id = 10,Name = "Tan shirt", Brand = "Vans", Color = "Tan", Gender = "Women", Price = 40, Size = new[] { "XS", "S", "M", "L", "XL" } },
        };
        public static List<ShirtDto> GetShirts()
        {
            return shirts;
        }
        public static bool ShirtExists(int id)
        {
            return shirts.Any(shirt => shirt.Id == id);
        }

        public static ShirtDto? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.Id == id);
        }
        public static ShirtDto? GetShirtByProperties(string? brand, string? gender, string? color, int? size)
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
                x.Size != null &&
                x.Size.Length > 0 &&
                size.Value == x.Size.Length);
        }
        public static void AddShirt(ShirtDto shirt)
        {
            int maxId = shirts.Max(x => x.Id);
            shirt.Id = maxId + 1;
            shirts.Add(shirt);
        }
        public static void UpdateShirt(ShirtDto shirt)
        {
            var shirtToUpdate = shirts.First(x => x.Id == shirt.Id);
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Size = shirt.Size;
            shirtToUpdate.Gender = shirt.Gender;
            shirtToUpdate.Price = shirt.Price;
        }

        public static void DeleteShirt(int id)
        {
            var shirt = GetShirtById(id);
            if (shirt != null)
            {
                shirts.Remove(shirt);
            }
        }

        internal static object GetShirtByProperties(string? brand, string? gender, string? color, string[]? size)
        {
            throw new NotImplementedException();
        }
    }
}
