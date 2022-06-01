using System.ComponentModel.DataAnnotations;

namespace Gestupperware.Api.Dtos.Categories
{
    public class EditCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}