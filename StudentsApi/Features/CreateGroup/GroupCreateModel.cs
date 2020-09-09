using System.ComponentModel.DataAnnotations;

namespace StudentsApi.Features.CreateGroup
{
    public class GroupCreateModel
    {
        [Required]
        [StringLength(25, ErrorMessage = "The Group name value cannot exceed 25 characters. ")]
        public string Name { get; set; }
    }
}
