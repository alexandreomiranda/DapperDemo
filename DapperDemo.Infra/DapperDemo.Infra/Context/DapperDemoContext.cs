using DapperDemo.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DapperDemo.Infra.Context
{
    public class DapperDemoContext : DbContext
    {
        public DapperDemoContext() : 
            base("DapperDemoConnectionString")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<DapperDemoContext>());
            //Database.Initialize(true);

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItens { get; set; }
        public DbSet<QuoteRequest> QuoteRequests { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Entity<PurchaseOrderItem>()
                .HasRequired(e => e.PurchaseOrder)
                .WithMany(c => c.PurchaseOrderItems)
                .HasForeignKey(e => e.PurchaseOrderId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
