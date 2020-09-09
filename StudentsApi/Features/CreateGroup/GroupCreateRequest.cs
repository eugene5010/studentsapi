using MediatR;

namespace StudentsApi.Features.CreateGroup
{
    public class GroupCreateRequest : IRequest<int>
    {
        public GroupCreateModel Model { get; set; }
    }
}
