using System.Collections.Generic;

namespace StudentsApi.Data.Models
{
    public class Student
    {
        public Student()
        {
            StudentGroups = new HashSet<StudentGroups>();
        }

        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Patronymic { get; set; }
        public string Code { get; set; }
        public string Sex { get; set; }

        public virtual ICollection<StudentGroups> StudentGroups { get; set; }
    }
}
