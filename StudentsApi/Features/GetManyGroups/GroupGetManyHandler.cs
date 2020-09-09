using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentsApi.Data.Models;

namespace StudentsApi.Features.GetManyGroups
{
    internal class GroupGetManyHandler : IRequestHandler<GroupsGetManyRequest, IEnumerable<GroupWithCount>>
    {
        private readonly StudentsContext _context;

        public GroupGetManyHandler(StudentsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GroupWithCount>> Handle(GroupsGetManyRequest request, CancellationToken cancellationToken) =>
            await _context.Group
                .IfWhere(() => !string.IsNullOrWhiteSpace(request.NameFilter), x => x.Name.Contains(request.NameFilter))
                .Select(x => new GroupWithCount()
                {
                    Id = x.Id,
                    Name = x.Name,
                    StudentCount = x.StudentGroups.Count
                })
                .ToArrayAsync(cancellationToken: cancellationToken);
    }
}
