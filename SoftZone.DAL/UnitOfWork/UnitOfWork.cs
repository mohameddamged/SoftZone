using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;

namespace SoftZone.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private Hashtable? _repositories;
        private IDbContextTransaction? _transaction;

        public ICityRepository Cities { get; }
        public IRestaurantRepository Restaurants { get; }
        public IMenuItemRepository MenuItems { get; }
        public IOrderRepository Orders { get; }
        public IOrderItemRepository OrderItems { get; }

        public UnitOfWork(
            AppDbContext context,
            ICityRepository cities,
            IRestaurantRepository restaurants,
            IMenuItemRepository menuItems,
            IOrderRepository orders,
            IOrderItemRepository orderItems)
        {
            _context = context;
            Cities = cities;
            Restaurants = restaurants;
            MenuItems = menuItems;
            Orders = orders;
            OrderItems = orderItems;
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            _repositories ??= new Hashtable();
            var typeName = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(typeName))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(
                    repositoryType.MakeGenericType(typeof(TEntity)),
                    _context);

                _repositories.Add(typeName, repositoryInstance!);
            }

            return (IGenericRepository<TEntity>)_repositories[typeName]!;
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task BeginTransactionAsync()
        {
            if (_transaction is null)
            {
                _transaction = await _context.Database.BeginTransactionAsync();
            }
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction is not null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction is not null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_transaction is not null)
            {
                await _transaction.DisposeAsync();
            }
            await _context.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }

}
