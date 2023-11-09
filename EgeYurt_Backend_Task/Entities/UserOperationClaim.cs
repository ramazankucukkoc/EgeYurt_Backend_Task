namespace EgeYurt_Backend_Task.Entities
{
    public class UserOperationClaim:BaseEntity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public virtual User User { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }

        public UserOperationClaim()
        {
        }

        public UserOperationClaim(int id, DateTime createdDate, DateTime updateDate, int userId, int operationClaimId) 
        {
            Id = id;
            CreatedDate = createdDate;
            UpdatedDate = updateDate;
            UserId = userId;
            OperationClaimId = operationClaimId;
        }
    }
}
