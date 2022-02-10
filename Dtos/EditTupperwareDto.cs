namespace GestupperwareApi.Dtos
{
    public class EditTupperwareDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public int CategoryId { get; set; }
        public int StorageId { get; set; }
    }
}