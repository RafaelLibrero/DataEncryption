using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataEncryption.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [Column("Username")]
        public string UserName { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("PasswordHash")]
        public byte[] PasswordHash { get; set; }
        [Column("Salt")]
        public string Salt { get; set; }
    }
}