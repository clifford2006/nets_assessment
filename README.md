# Product System Design &amp; Implementation Assessment
## Task 1: Problem Framing & Assumptions

## 1. Key Assumptions

### 1.1 Expected transaction volume and peak behaviour
- Since it involves internal and external clients, initial payment instruction could reach 1k-10k per day
- System needs to scale as external clients grow up to millions of payment instructions per day
- Traffic will peak when performing end of day settlements/reconcillations.
- System will need to do:
  - Horizontal scalability
  - Schedulers / async processing

---

### 1.2 Ordering, idempotency, and duplicate handling
- Payment instructions will not come in order for all accounts (Internal + External)
- `Instruction ID` and `Source system` will act as **idempotency key** to prevent duplicates
- In the event of duplicate submissions for payment instruction:
  - System needs to detect and perform action to prevent duplicate payment instructions
  - Return existing payment instruction status when required
  
---

### 1.3 Data integrity, audit, and compliance requirements
- Payment instructions must strictly not perform `hard delete`, where it will only perform `soft delete` when required/requested
- For audit:
  - Payment instruction may include additional `Source creation date` to log date of creation for each payment instruction in the system
  - Record whenever instruction status changes (new+old value) with its timestamp
- For compliance:
  - 