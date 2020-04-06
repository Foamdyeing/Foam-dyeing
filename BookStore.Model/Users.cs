using System;

namespace BookStore.Model
{
    public class Users
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public string Photo { get; set; }
        public int RolesId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}