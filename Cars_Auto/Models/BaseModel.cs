using System.ComponentModel.DataAnnotations;

namespace Cars_Auto.Models
{
    public class BaseModel
    {
        
        public int Id { get; set; }
        [MaxLength(length: 250)]
        public string Name { get; set; } = string.Empty;
    }
}
