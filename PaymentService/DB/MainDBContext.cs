using Microsoft.EntityFrameworkCore;
using static PaymentService.Modals.PaymentInstructionModal;

namespace PaymentService.DB
{
    public class MainDBContext(DbContextOptions<MainDBContext> options) : DbContext(options)
    {
        public DbSet<PaymentInstruction> PaymentInstructions => Set<PaymentInstruction>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentInstruction>()
                .HasKey(p => new { p.InstructionId, p.SourceSystem });

            modelBuilder.Entity<PaymentInstruction>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);
        }
    }
}
