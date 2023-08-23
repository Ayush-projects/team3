using Microsoft.EntityFrameworkCore;
namespace BankAtm.Entities

{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options):base(options) { }
        public DbSet<Customer> Customers { get; set;}
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=WINDOWS-BVQNF6J;Database=BankData;trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>()
                .HasIndex(p => p.AccNum)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>()
                .HasIndex(p => p.Email)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Transaction>()
                .HasIndex(p => p.TransID)
                .IsUnique();

        }
    }
}
