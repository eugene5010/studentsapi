using System.Linq;
using System.Runtime.CompilerServices;
using AutoMapper;
using StudentsApi.Features.GetManyStudents;

[assembly: InternalsVisibleTo("StudentsApi.Tests")]

namespace StudentsApi.Data.Profiles
{
    internal class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Data.Models.Student, Student>()
                .ForMember(dst => dst.StudentGroups, opt 
                    => opt.MapFrom(src => string.Join(',', src.StudentGroups
                            .Select((item) => item.Group.Name))))
                .ReverseMap();
            CreateMap<Features.CreateStudent.StudentCreateModel, Data.Models.Student>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.StudentGroups, opt => opt.Ignore());
        }
    }
}
