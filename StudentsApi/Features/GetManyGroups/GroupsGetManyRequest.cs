using System.Collections.Generic;
using MediatR;

namespace StudentsApi.Features.GetManyGroups
{
    public class GroupsGetManyRequest : IRequest<IEnumerable<GroupWithCount>>
    {
        public string NameFilter { get; set; }
    }
}
