using System.ComponentModel.DataAnnotations;

namespace GestupperwareApi.Dtos.Categories
{
    public class EditCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}