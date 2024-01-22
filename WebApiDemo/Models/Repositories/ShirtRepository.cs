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
        public static bool ShirtExists(int id)
        {
            return shirts.Any(shirt => shirt.Id == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.Id == id);
        }
    }
}
