using System.ComponentModel.DataAnnotations.Schema;

namespace Cars_Auto.Models
{
	public class Purchase:BaseModel
	{
		public int ?UserId { get; set; }
		public User ?User { get; set; } = default!;

		public int CarId { get; set; }
		public Car Car { get; set; } = default!;

		public DateTime PurchaseDate { get; set; } = DateTime.Now;
		[Column(TypeName = "decimal(18,2)")]
		public decimal FinalPrice { get; set; }
	}
}
