using Microsoft.AspNetCore.Identity;

namespace EgeYurt_Backend_Task.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Customer()
        {

        }
        public Customer(int id, DateTime createdDate, DateTime updateDate, string firstName, string lastName, string email, string address, bool isDeleted)
        {
            Id = id;
            CreatedDate = createdDate;
            UpdatedDate = updateDate;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            IsDeleted = isDeleted;
        }
    }

}
