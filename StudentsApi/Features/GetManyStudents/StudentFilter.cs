namespace StudentsApi.Features.GetManyStudents
{
    public class StudentFilter
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Patronymic { get; set; }
        public string Groupname { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
