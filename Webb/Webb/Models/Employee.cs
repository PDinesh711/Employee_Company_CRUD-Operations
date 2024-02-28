using System.ComponentModel.DataAnnotations;

namespace Webb.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EmpName { get; set; }
        [Required]
        public string EmpJoin {  get; set; }
        [Required]
        public string EmpAddress { get; set; }
        [Required]
        public string EmpGender { get; set; }
        [Required]
        public int EmpMobile { get; set; }
        [Required]
        public string EmpMail { get; set; }
    }
}
