namespace GestupperwareApi.Models
{
    public class Storage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Tupperware> Tupperwares { get; set; }
    }
}