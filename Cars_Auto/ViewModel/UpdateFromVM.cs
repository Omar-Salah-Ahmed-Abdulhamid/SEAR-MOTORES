using Cars_Auto.Attributes;

namespace Cars_Auto.ViewModel
{
    public class UpdateFromVM:CarFromViewModel
    {
        public int id { get; set; }
		public string? CurrentCover { get; set; }

		[AllowedExtensions(FileSiting.AllowedExtensions),
            MaxSizeExtention(FileSiting.MaxSizinByte)]
        public IFormFile ?cover { get; set; } = default!;
		public List<IFormFile> ?Images { get; set; } = new List<IFormFile>();

	}
}
