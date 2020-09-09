using System.ComponentModel.DataAnnotations;
using MediatR;

namespace StudentsApi.Features.AttachStudent
{
    public class AttachStudentRequest : IRequest, IRequest<int>
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int GroupId { get; set; }
        [Range(0, int.MaxValue)]
        public int StudentId { get; set; }
    }
}
