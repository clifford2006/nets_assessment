using static PaymentService.Modals.PaymentInstructionModal;

namespace PaymentService.Util
{
    public static class PaymentInstructionUtil
    {
        public static void ValidatePaymentInstruction(PaymentInstructionRequest instructionRequest)
        {
            if (string.IsNullOrWhiteSpace(instructionRequest.InstructionId.ToString()))
                throw new ArgumentException("InstructionId is required.");

            if (string.IsNullOrWhiteSpace(instructionRequest.Currency))
                throw new ArgumentException("Currency is required.");

            if (string.IsNullOrWhiteSpace(instructionRequest.SourceSystem))
                throw new ArgumentException("SourceSystem is required.");

            if (instructionRequest.Amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            if (instructionRequest.RequestedExecutionDate.Date < DateTime.UtcNow.Date)
                throw new ArgumentException("Requested execution date cannot be in the past.");

            if (instructionRequest.PayerAccount == instructionRequest.PayeeAccount)
                throw new ArgumentException("Payer and Payee accounts must be different.");
        }
    }
}
