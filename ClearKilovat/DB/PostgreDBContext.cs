using ClearKilovat.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClearKilovat.DB
{
    public class PostgreDBContext :DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Consumption> Consumptions { get; set; }
        public DbSet<NnResult> NNResults { get; set; }
        public DbSet<ParserAnalytics> ParserAnalytics { get; set; }
        public DbSet<SmartMeter> SmartMeters { get; set; }
        public DbSet<SmartMeterReading> SmartMeterReadings { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }


        public PostgreDBContext(DbContextOptions<PostgreDBContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Account → ParserAnalytics  (1-к-1)
            modelBuilder.Entity<Account>()
                .HasOne(a => a.ParserAnalytics)
                .WithOne(p => p.Account)
                .HasForeignKey<ParserAnalytics>(p => p.AccountId);

            // Account → NnResult (1-к-1)
            modelBuilder.Entity<Account>()
                .HasOne(a => a.NnResult)
                .WithOne(n => n.Account)
                .HasForeignKey<NnResult>(n => n.AccountId);
        }

    }
}
