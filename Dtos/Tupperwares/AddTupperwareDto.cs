using System.ComponentModel.DataAnnotations;

namespace GestupperwareApi.Dtos.Tupperwares
{
    public class AddTupperwareDto
    {
        [Required]
        public string Name { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        [Required]
        public int? StorageId { get; set; }
    }
}