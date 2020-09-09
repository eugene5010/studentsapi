using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsApi.Features.GetManyGroups
{
    public class GroupWithCount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentCount { get; set; }
    }
}
