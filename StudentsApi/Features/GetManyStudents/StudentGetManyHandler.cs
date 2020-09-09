using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentsApi.Data.Models;
using StudentsApi.Handlers;

namespace StudentsApi.Features.GetManyStudents
{
    internal class StudentGetManyHandler : BaseMappingHandler<StudentGetManyRequest, Data.Models.Student, Student>
    {
        private readonly StudentsContext _context;

        public StudentGetManyHandler(IMapper mapper, StudentsContext context) : base(mapper)
        {
            _context = context;
        }


        protected override async Task<IEnumerable<Data.Models.Student>> GetData(StudentGetManyRequest request)
        {
            if (request.Filter?.PageSize <= 0 || request.Filter?.Page < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(request.Filter));
            }

            return await _context.Student
                .IfWhere(() => !string.IsNullOrWhiteSpace(request.Filter?.Firstname), x
                    => x.Firstname.Contains(request.Filter.Firstname))
                .IfWhere(() => !string.IsNullOrWhiteSpace(request.Filter?.Patronymic), x
                    => x.Patronymic.Contains(request.Filter.Patronymic))
                .IfWhere(() => !string.IsNullOrWhiteSpace(request.Filter?.Lastname), x
                    => x.Lastname.Contains(request.Filter.Lastname))
                .IfWhere(() => !string.IsNullOrWhiteSpace(request.Filter?.Groupname), x
                    => x.StudentGroups.Any(gr => gr.Group.Name.Contains(request.Filter.Groupname)))
                .SkipWhen(() => request.Filter?.PageSize > 0 && request.Filter.Page > 0,
                    request.Filter.PageSize * (request.Filter.Page - 1))
                .TakeWhen(() => request.Filter?.PageSize > 0, request.Filter.PageSize)
                .Include(x => x.StudentGroups)
                .ThenInclude(x => x.Group)
                .ToArrayAsync();
        }

    }
}
