namespace StudentsApi.Data.Models
{
    public class StudentGroups
    {
        public int StudentId { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Student Student { get; set; }
    }
}
