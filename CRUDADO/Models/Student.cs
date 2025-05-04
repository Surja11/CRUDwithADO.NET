using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CRUDADO.Models
{
    public class Student
    {
        [Key]
        public int Roll { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }   
        
        [Required]
        [DisplayName("Last Name")]
        public string LastName {  get; set; }
        
        [Required]
        public string Semester { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        public int Phone {  get; set; }

        [Required]
        [DisplayName("Marks Obtained")]
        public int MarksObtained { get; set; }

    }
}
