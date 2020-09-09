using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using StudentsApi.Data.Models;

namespace StudentsApi.Features.CreateStudent
{
    internal class StudentCreateHandler : IRequestHandler<StudentCreateRequest, int>
    {
        private readonly StudentsContext _context;
        private readonly IMapper _mapper;

        public StudentCreateHandler(StudentsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(StudentCreateRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.Student.AddAsync(_mapper.Map<Features.CreateStudent.StudentCreateModel, Data.Models.Student>(request.Model), cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            return entity.Entity.Id;
        }
    }
}
