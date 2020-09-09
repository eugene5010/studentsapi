using System.Collections.Generic;
using MediatR;
using StudentsApi.Data.Models;

namespace StudentsApi.Features.GetManyStudents
{
    public class StudentGetManyRequest : IRequest<IEnumerable<Student>>
    {
        public StudentFilter Filter { get; set; }
    }
}
