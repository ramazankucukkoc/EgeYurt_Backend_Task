﻿namespace EgeYurt_Backend_Task.Services.Customers
{
    public class CreateCustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }

    }
}
