using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentsApi.Data.Models;
using StudentsApi.Features.CreateStudent;
using StudentsApi.Features.GetManyStudents;
using Student = StudentsApi.Features.GetManyStudents.Student;

namespace StudentsApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class StudentController
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<int> CreateStudent(StudentCreateModel student) =>
            await _mediator.Send(new StudentCreateRequest()
            {
                Model = student
            });

        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudents(string firstname, string lastname, string patronymic, string groupname, int page, int pagesize) =>
            await _mediator.Send(new StudentGetManyRequest()
            {
                Filter = new StudentFilter()
                {
                    PageSize = pagesize,
                    Page = page,
                    Groupname = groupname,
                    Lastname = lastname,
                    Patronymic = patronymic,
                    Firstname = firstname
                }
            });
    }
}
