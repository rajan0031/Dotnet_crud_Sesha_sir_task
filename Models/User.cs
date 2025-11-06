using System.ComponentModel.DataAnnotations; // used for seetting key , required , simple schema validations 
using System.ComponentModel.DataAnnotations.Schema; //  used for this DatabaseGeneratedOption

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