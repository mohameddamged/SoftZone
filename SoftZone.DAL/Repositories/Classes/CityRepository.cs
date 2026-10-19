
namespace SoftZone.DAL
{
   public class CityRepository : GenericRepository<City>, ICityRepository
   {
        public CityRepository(AppDbContext context) : base(context)
        {
        }
   }
}
