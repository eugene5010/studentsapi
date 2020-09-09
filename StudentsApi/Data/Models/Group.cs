using System.Collections.Generic;

namespace StudentsApi.Data.Models
{
    public class Group
    {
        public Group()
        {
            StudentGroups = new HashSet<StudentGroups>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentGroups> StudentGroups { get; set; }
    }
}
