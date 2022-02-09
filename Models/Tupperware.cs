namespace GestupperwareApi.Models
{
    public class Tupperware
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public int IdCategory { get; set; }
        public Category Category { get; set; }
        public int IdStorage { get; set; }
        public Storage Storage { get; set; }
    }
}