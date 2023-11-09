namespace EgeYurt_Backend_Task.Entities
{
    public class OperationClaim:BaseEntity
    {
        public string Name { get; set; }
        public OperationClaim()
        {
            
        }
        public OperationClaim(int id ,string name,DateTime createdDate,DateTime updateDate,bool isDeleted)
        {
            Id = id ;
            Name = name ;
            CreatedDate = createdDate ;
            UpdatedDate = updateDate ;
            IsDeleted = isDeleted ;
        }
    }
}
