using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StudentsApi.Data.Models;

namespace StudentsApi.Features.CreateGroup
{
    internal class GroupCreateHandler : IRequestHandler<GroupCreateRequest, int>
    {
        private readonly StudentsContext _context;

        public GroupCreateHandler(StudentsContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(GroupCreateRequest request, CancellationToken cancellationToken)
        {
            var result = (await _context.Group.AddAsync(new Group()
            {
                Name = request.Model.Name,
            }, cancellationToken));

            await _context.SaveChangesAsync(cancellationToken);
            return result.Entity.Id;
        }
    }
}
