using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentsApi.Data.Models;
using StudentsApi.Features.AttachStudent;
using StudentsApi.Features.CreateGroup;
using StudentsApi.Features.GetManyGroups;
using StudentsApi.Models;
using Swashbuckle.Swagger.Annotations;

namespace StudentsApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class GroupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<int> CreateGroup(GroupCreateModel model) =>
            await _mediator.Send(new GroupCreateRequest()
            {
                Model = model
            });

        [HttpPut]
        public async Task AttachStudent(int groupId, int studentId) =>
            await _mediator.Send(new AttachStudentRequest()
            {
                StudentId = studentId,
                GroupId = groupId
            });

        [HttpGet]
        [Route("list")]
        public async Task<IEnumerable<GroupWithCount>> GetGroups(string nameFilter) =>
            await _mediator.Send(new GroupsGetManyRequest()
            {
                NameFilter = nameFilter
            });
    }
}
