
namespace SoftZone.DAL
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public double Rating { get; set; }
        public int ReviewsCount { get; set; }
        public int LikesCount { get; set; }

        // Foreign Key
        public int CityId { get; set; }
        public City City { get; set; } = null!;

        // Navigation Properties
        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
