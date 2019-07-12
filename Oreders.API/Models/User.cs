using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Oreders.API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSlat { get; set; }
        public string Role { get; set; }
        public ICollection<Order> orders { get; set; }
    }
}