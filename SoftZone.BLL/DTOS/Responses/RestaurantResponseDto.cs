namespace SoftZone.BLL
{
    public class RestaurantResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public double Rating { get; set; }
        public int ReviewsCount { get; set; }
        public int LikesCount { get; set; }
        public int CityId { get; set; }
    }
}
