using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCrudAPI.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
        public int Id { get; set; }

        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}