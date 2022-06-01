using Gestupperware.Api.Dtos.Categories;
using Gestupperware.Api.Dtos.Storages;

namespace Gestupperware.Api.Dtos.Tupperwares
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