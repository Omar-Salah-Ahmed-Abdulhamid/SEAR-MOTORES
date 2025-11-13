using Cars_Auto.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Cars_Auto.ViewModel
{
    public class CreatCarFromVM:CarFromViewModel
    {
        
        
        [AllowedExtensions(FileSiting.AllowedExtensions),
            MaxSizeExtention(FileSiting.MaxSizinByte)]
        public IFormFile cover { get; set; } = default!;

		public List<IFormFile> Images { get; set; } =new List<IFormFile>();

	}
}

