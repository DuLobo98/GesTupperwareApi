namespace GestupperwareApi.Models
{
    public class Tupperware
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int StorageId { get; set; }
        public Storage Storage { get; set; }
    }
}