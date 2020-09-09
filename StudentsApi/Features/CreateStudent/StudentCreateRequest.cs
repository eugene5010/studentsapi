using MediatR;

namespace StudentsApi.Features.CreateStudent
{
    public class StudentCreateRequest : IRequest<int>
    {
        public StudentCreateModel Model { get; set; }
    }
}
