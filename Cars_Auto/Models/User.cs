using Microsoft.AspNetCore.Identity;

namespace Cars_Auto.Models
{
	public class User:BaseModel
	{
        public string Email { get; set; }=string.Empty;
		public string Password { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public string Role { get; set; } = "User";
	}
}
