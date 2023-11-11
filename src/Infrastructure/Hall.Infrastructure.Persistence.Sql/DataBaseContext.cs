using Framework.Domain;
using Framework.EntityFrameworkCore.OutBox;
using Hall.Domain.Models.Categories;
using Hall.Infrastructure.Persistence.Sql.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hall.Infrastructure.Persistence.Sql;

public class DataBaseContext :DbContext
{
     private readonly IRequestContext _requestContext;
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        public DbSet<EventProcessedMessage> EventProcessedMessages { get; set; }    
        public DbSet<ExceptionLogModel> ExceptionLogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DataBaseContext(IRequestContext requestContext)
        {
            _requestContext = requestContext;
        }
        public DataBaseContext(DbContextOptions options, IRequestContext requestContext) : base(options)
        {
            _requestContext = requestContext;
            //Database.Migrate();
            this.SavingChanges += OnSavingChanges;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasSequence<long>("AssetNumbers").StartsAt(1).IncrementsBy(1);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            new OutboxMessageMapping().Configure(modelBuilder.Entity<OutboxMessage>());
        }
        private void OnSavingChanges(object sender, SavingChangesEventArgs e)
        {
            AddToProcessedMessages();
            AddToOutBoxItems();
        }
        
        private void AddToProcessedMessages()
        {
            if (_requestContext.GetCommandId() != null && _requestContext.GetCommandId() != Guid.Empty)
            {
                EventProcessedMessageRepository.AddMessage( this,new (_requestContext.GetCommandId()));
                _requestContext.ClearContext();
            }
        }
        private void AddToOutBoxItems()
        {
            var aggregateRoots = this.ChangeTracker.Entries()
                .Where(a => a.State != EntityState.Unchanged)
                .Select(a => a.Entity)
                .OfType<IAggregateRoot>()
                .ToList();
            var itemsToAddIntoOutbox = OutboxItemFactory.CreateOutboxItemsFromAggregateRoots(aggregateRoots);
            itemsToAddIntoOutbox.ForEach(a => OutboxMessages.Add(a));
        }
}
