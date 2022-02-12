using System.ComponentModel.DataAnnotations;

namespace GestupperwareApi.Dtos.Storages
{
    public class EditStorageDto
    {
        [Required]
        public string Name { get; set; }
    }
}