
using ChariTov.DataModels;
using System.ComponentModel.DataAnnotations;

namespace ChariTov.Models
{
    public class User
    {
        public int Id { get; set; }

        [Key]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public List<Role> Roles { get; set; }
    }
}
