namespace WebApiDemo.Models.Repositories
{
    public static class ShirtRepository
    {
        private static List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt {Id = 1,Brand = "My Brand",Color = "Red",Gender = "Men",Price = 30,Size = 10},
            new Shirt {Id = 2,Brand = "My Brand",Color = "Red",Gender = "Men",Price = 30,Size = 10},
            new Shirt {Id = 3,Brand = "My Brand",Color = "Red",Gender = "Men",Price = 30,Size = 10},
            new Shirt {Id = 4,Brand = "My Brand",Color = "Red",Gender = "Men",Price = 30,Size = 10}
        };
        public static List<Shirt> GetShirts()
        {
            return shirts;
        }
        public static bool ShirtExists(int id)
        {
            return shirts.Any(shirt => shirt.Id == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.Id == id);
        }
        public static Shirt? GetShirtByProperties(string? brand, string? gender, string? color, int? size)
        {
            return shirts.FirstOrDefault(x => !string.IsNullOrWhiteSpace(brand) &&
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
            size.HasValue == x.Size.HasValue);
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
    }
}
