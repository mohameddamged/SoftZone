namespace SoftZone.DAL
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICityRepository Cities { get; }
        IRestaurantRepository Restaurants { get; }
        IMenuItemRepository MenuItems { get; }
        IOrderRepository Orders { get; }
        IOrderItemRepository OrderItems { get; }

        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}

