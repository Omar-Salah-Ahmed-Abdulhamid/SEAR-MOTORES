using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars_Auto.ViewModel
{
    public class CarFromViewModel
    {
        [MaxLength(length: 200)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(length: 2500)]
        public string Description { get; set; } = string.Empty;
        [MaxLength(length: 200)]
        [Display(Name = "Brand")]
        public string BrandName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [MaxLength(length: 250)]
        public string Country { get; set; } = string.Empty;
        //public int  BrandId  { get; set; } = default!;
        [Display(Name = "Categoriey")]
        public int CategorieyId { get; set; } = default!;
        public IEnumerable<SelectListItem> Catogryies { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
