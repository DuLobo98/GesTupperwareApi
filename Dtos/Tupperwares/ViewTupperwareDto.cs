using GestupperwareApi.Dtos.Categories;
using GestupperwareApi.Dtos.Storages;

namespace GestupperwareApi.Dtos.Tupperwares
{
    public class ViewTupperwareDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public ViewCategoryDto Category { get; set; }
        public ViewStorageDto Storage { get; set; }
    }
}