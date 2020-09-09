using System.ComponentModel.DataAnnotations;
using StudentsApi.Features.GetManyStudents;
using StudentsApi.Models;

namespace StudentsApi.Features.CreateStudent
{
    public class StudentCreateModel
    {
        [Required]
        [StringLength(40, ErrorMessage = "The First name value cannot exceed 40 characters. ")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "The Last name value cannot exceed 40 characters. ")]
        public string Lastname { get; set; }
        
        public string Code { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "The Patronymic value cannot exceed 60 characters. ")]
        public string Patronymic { get; set; }

        [Required]
        public Sex Sex { get; set; }
    }
}
