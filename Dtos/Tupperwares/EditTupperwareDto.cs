using System.ComponentModel.DataAnnotations;

namespace GestupperwareApi.Dtos.Tupperwares
{
    public class EditTupperwareDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required]
        public double? Price { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        [Required]
        public int? StorageId { get; set; }
    }
}