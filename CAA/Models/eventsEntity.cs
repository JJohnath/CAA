using System.ComponentModel.DataAnnotations;

namespace CAA.Models
{
    public class eventsEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime EventDate { get; set; }
        public string EventTitle { get; set; }
        public string Desc { get; set; }
        public string Capacity { get; set; }
        public string Email { get; set; }


    }
}
