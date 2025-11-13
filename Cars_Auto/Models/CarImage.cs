using System.ComponentModel.DataAnnotations;

namespace Cars_Auto.Models
{
	public class CarImage
	{
        public int Id { get; set; }
        [MaxLength(length:500)]
		public string ImageUrl { get; set; } = string.Empty;
		public int carid { get; set; }
		public Car car { get; set; } = default!;

    }
}
