using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StudentsApi.Data.Models;

namespace StudentsApi.Features.AttachStudent
{
    public class AttachStudentHandler : IRequestHandler<AttachStudentRequest>
    {
        private readonly StudentsContext _context;

        public AttachStudentHandler(StudentsContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AttachStudentRequest request, CancellationToken cancellationToken)
        {
            await using var uow = await _context.Database.BeginTransactionAsync(cancellationToken);

            var group = _context.Group.SingleOrDefault(x => x.Id == request.GroupId);
            if (group == null)
            {
                throw new ArgumentNullException($"Group with identifier: {request.GroupId} wasn't found");
            }

            await _context.StudentGroups.AddAsync(new StudentGroups()
            {
                GroupId = request.GroupId,
                StudentId = request.StudentId
            });

            await _context.SaveChangesAsync(cancellationToken);

            await uow.CommitAsync(cancellationToken);
            return new Unit();
        }
    }
}
