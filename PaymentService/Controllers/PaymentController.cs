using Microsoft.AspNetCore.Mvc;
using PaymentService.DB;
using PaymentService.Util;
using static PaymentService.Modals.PaymentInstructionModal;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController(MainDBContext db) : ControllerBase
    {
        [HttpGet("GetInstructionStatus")]
        public async Task<IActionResult> GetInstructionStatus(Guid id, string sourceSystem)
        {
            try
            {
                InstructionStatus? status = await PaymentInstructionDBUtil.GetPaymentInstructionStatus(db, id, sourceSystem);

                return status != null ? Ok(status) : NotFound($"Instruction {id} Not Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateInstruction")]
        public async Task<ActionResult> CreateInstruction(PaymentInstructionRequest request)
        {
            try
            {
                PaymentInstructionUtil.ValidatePaymentInstruction(request);

                PaymentInstruction? existingInstruction = await PaymentInstructionDBUtil.GetPaymentInstruction(db, request.InstructionId, request.SourceSystem);
                if (existingInstruction != null)
                {
                    return Ok(existingInstruction);
                }

                PaymentInstruction paymentInstruction = new()
                {
                    InstructionId = request.InstructionId,
                    SourceSystem = request.SourceSystem,
                    PayerAccount = request.PayerAccount,
                    PayeeAccount = request.PayeeAccount,
                    Amount = request.Amount,
                    Currency = request.Currency,
                    RequestedExecutionDate = request.RequestedExecutionDate,
                    Status = InstructionStatus.Received,
                    CreatedDate = DateTime.Now
                };
                return Ok(await PaymentInstructionDBUtil.CreatePaymentInstruction(db, paymentInstruction));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
