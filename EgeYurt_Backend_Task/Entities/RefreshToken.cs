namespace EgeYurt_Backend_Task.Entities
{
    public class RefreshToken:BaseEntity
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public string CreatedByIp { get; set; }
        public virtual User User { get; set; }
        public RefreshToken()
        {

        }
        public RefreshToken(int id, DateTime createdDate, DateTime updateDate, string token, DateTime expires, string createdByIp)
                       
        {
            Id = id;
            CreatedDate = createdDate;
            UpdatedDate = updateDate;
            Token = token;
            Expires = expires;
            CreatedByIp = createdByIp;
        }
    }
}
