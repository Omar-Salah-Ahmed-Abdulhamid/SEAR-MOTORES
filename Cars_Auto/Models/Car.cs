using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars_Auto.Models
{
    public class Car:BaseModel
    {
        [MaxLength(length:2500)]
        public string Description { get; set; } = string.Empty;
        [MaxLength(length: 500)]
        public string cover { get; set; } = string.Empty;
		[MaxLength(length: 250)]
		public string BrandName { get; set; }= string.Empty;
		[Column(TypeName = "decimal(18,2)")]
		public decimal Price { get; set; }
		[MaxLength(length: 250)]
		public string Country { get; set; } = string.Empty;
        // داخل Car Model
        public ICollection<CarImage> Images { get; set; }= new List<CarImage>();
		//public int BrandId { get; set; }
		public int CategorieyId { get; set; }
        //public Brand Brand { get; set; } = default!;
        public Categoriey Categoriey { get; set; } = default!;

    }
}
