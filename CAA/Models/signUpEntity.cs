using System.ComponentModel.DataAnnotations;

namespace CAA.Models
{
    public class signUpEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
