using System.ComponentModel.DataAnnotations;

namespace Webb.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string role { get; set; }
        [Required]
        public string fromDate { get; set; }
        [Required]
        public string toDate { get; set; }
        [Required]
        public int experiences { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        public string city { get; set; }

    }
}
