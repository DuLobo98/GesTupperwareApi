using System.ComponentModel.DataAnnotations;

namespace GestupperwareApi.Models
{
    public class Storage
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Tupperware> Tupperwares { get; set; }
    }
}