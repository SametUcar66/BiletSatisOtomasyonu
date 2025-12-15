using System;

namespace BiletSatis.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string TCNo { get; set; }
        public string Address { get; set; }
        public UserType UserType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public bool IsActive { get; set; }
    }

    public enum UserType
    {
        SuperAdmin = 0,
        AgencyManager = 1,
        AgencyEmployee = 2,
        Driver = 3,
        Company = 4,
        Individual = 5
    }
}