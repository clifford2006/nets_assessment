using Microsoft.EntityFrameworkCore;
using static PaymentService.Modals.PaymentInstructionModal;

namespace PaymentService.DB
{
    public class PaymentInstructionDBUtil
    {
        public static async Task<InstructionStatus?> GetPaymentInstructionStatus(MainDBContext dbContext, Guid guid, string sourceSystem)
        {
            var existing = await dbContext.PaymentInstructions.FirstOrDefaultAsync(i => i.InstructionId == guid && i.SourceSystem.Equals(sourceSystem));

            return existing?.Status;
        }

        public static async Task<PaymentInstruction?> GetPaymentInstruction(MainDBContext dbContext, Guid guid, string sourceSystem)
        {
            var existing = await dbContext.PaymentInstructions.FirstOrDefaultAsync(i => i.InstructionId == guid && i.SourceSystem.Equals(sourceSystem));

            return existing;
        }

        public static async Task<PaymentInstruction?> CreatePaymentInstruction(MainDBContext dbContext, PaymentInstruction paymentInstruction)
        {
            dbContext.PaymentInstructions.Add(paymentInstruction);
            await dbContext.SaveChangesAsync();

            return paymentInstruction;
        }
    }
}
