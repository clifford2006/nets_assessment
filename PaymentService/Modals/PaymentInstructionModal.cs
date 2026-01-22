namespace PaymentService.Modals
{
    public class PaymentInstructionModal
    {
        public enum InstructionStatus
        {
            Received,
            Processed,
            Rejected,
            Cancelled
        }

        public class PaymentInstruction
        {
            public required Guid InstructionId { get; set; }
            public required string SourceSystem { get; set; }
            public required string PayerAccount { get; set; }
            public required string PayeeAccount { get; set; }
            public required decimal Amount { get; set; }
            public required string Currency { get; set; }
            public required DateTime RequestedExecutionDate { get; set; }
            public required InstructionStatus Status { get; set; }
            public required DateTime CreatedDate { get; set; }
        }

        public class PaymentInstructionRequest
        {
            public required Guid InstructionId { get; set; }
            public required string SourceSystem { get; set; }
            public required string PayerAccount { get; set; }
            public required string PayeeAccount { get; set; }
            public required decimal Amount { get; set; }
            public required string Currency { get; set; }
            public required DateTime RequestedExecutionDate { get; set; }
        }
    }
}
