using Edgias.Agrik.ApplicationCore.Entities;
using Edgias.Agrik.ApplicationCore.Exceptions;
using Edgias.Agrik.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Edgias.Agrik.Infrastructure.Data
{
    public class AgrikDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public AgrikDbContext(DbContextOptions<AgrikDbContext> options, 
            IDomainEventDispatcher domainEventDispatcher)
            :base(options)
        {
            _domainEventDispatcher = domainEventDispatcher;
        }

        public DbSet<Crop> Crops { get; set; }

        public DbSet<CropCategory> CropCategories { get; set; }

        public DbSet<CropUnit> CropUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                int result = await base.SaveChangesAsync(cancellationToken);

                // dispatch events only if save was successful
                var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                    .Select(e => e.Entity)
                    .Where(e => e.Events.Any())
                    .ToArray();

                foreach (var entity in entitiesWithEvents)
                {
                    var events = entity.Events.ToArray();

                    entity.Events.Clear();

                    foreach (var domainEvent in events)
                    {
                        _domainEventDispatcher.Dispatch(domainEvent);
                    }
                }

                return result;
            }

            catch(DbUpdateException e)
            {
                throw new DataStoreException(e.Message, e);
            }

        }
    }
}
