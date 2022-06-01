using System.ComponentModel.DataAnnotations;

namespace Gestupperware.Api.Models
{
    public class Tupperware
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int StorageId { get; set; }
        public virtual Storage Storage { get; set; }
    }
}