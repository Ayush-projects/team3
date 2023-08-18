using Microsoft.EntityFrameworkCore;

namespace BankAPI.Entites
{
    public class BankContext:DbContext
    {
        public BankContext(DbContextOptions<BankContext> options):base(options)
        {  
        }
        //Entity sets
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        //public DbSet<Transaction> Transactions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=WINDOWS-BVQNF6J;Database=BankData;trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>()
                .HasIndex(p => p.AccNum)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Transaction>()
                .HasIndex(p => p.TransID)
                .IsUnique();
            */
        }
    }
}
