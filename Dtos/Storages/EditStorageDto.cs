using System.ComponentModel.DataAnnotations;

namespace Gestupperware.Api.Dtos.Storages
{
    public class EditStorageDto
    {
        [Required]
        public string Name { get; set; }
    }
}