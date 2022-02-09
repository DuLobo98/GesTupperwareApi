namespace GestupperwareApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Tupperware> Tupperwares { get; set; }
    }
}