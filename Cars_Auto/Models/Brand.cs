using System.ComponentModel.DataAnnotations;

namespace Cars_Auto.Models
{
    public class Brand:BaseModel
    {
        // oudi bm togg ceer //
        [MaxLength(length: 100)]
        public string Country { get; set; } = string.Empty;

        public string Logo { get; set; }= string.Empty;
    }
}
