using System.ComponentModel.DataAnnotations;

namespace CAA.Models
{
    public class LeadEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime LeadDate { get; set; }
        public string LeadSource { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }


    }
}
