namespace GestupperwareApi.Dtos.Tupperwares
{
    public class ViewTupperwareDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public CategoryDto Category { get; set; }
        public StorageDto Storage { get; set; }
    }
}