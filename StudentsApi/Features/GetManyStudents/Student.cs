namespace StudentsApi.Features.GetManyStudents
{
    public enum Sex { Male, Female }

    public class Student
    {
        public int Id { get; set; }
        public Sex Sex { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Patronymic { get; set; }
        public string Code { get; set; }
        public string StudentGroups { get; set; }
    }
}
