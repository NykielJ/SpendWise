using Microsoft.EntityFrameworkCore;

namespace SpendWise.Models
{
    public class UserDataContext : DbContext
    {
        public UserDataContext(DbContextOptions<UserDataContext> options) : base(options)
    {
    }
        public DbSet<User> Users { get; set; }
        public DbSet<BudgetPlan> BudgetPlans { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Notification> Notifications { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=spendwise.db"); // nie wiem co to
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<BudgetPlan>().ToTable("BudgetPlans");
            modelBuilder.Entity<Transaction>().ToTable("Transactions");
            modelBuilder.Entity<ExpenseCategory>().ToTable("ExpenseCategories");
            modelBuilder.Entity<Notification>().ToTable("Notifications");


            // Konfiguracja relacji
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Category)
                .WithMany()
                .HasForeignKey(t => t.CategoryId);

            modelBuilder.Entity<BudgetPlan>()
                .HasOne(bp => bp.User)
                .WithMany(u => u.BudgetPlans)
                .HasForeignKey(bp => bp.UserId);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId);
        }
    }

    
}