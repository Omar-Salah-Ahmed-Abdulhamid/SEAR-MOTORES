using System.ComponentModel.DataAnnotations;

namespace Cars_Auto.Attributes
{
	public class AllowedExtensions:ValidationAttribute
	{
		private readonly string _allowedExtensions;

		public AllowedExtensions(string allowedExtensions)
		{
			_allowedExtensions = allowedExtensions;
		}

		protected override ValidationResult? IsValid
			(object? value, ValidationContext validationContext)
		{
			var file=value as IFormFile;
			if (file is not null)
			{
				var extention=Path.GetExtension(file.FileName);

				var isAllowed=_allowedExtensions.Split(separator:",").Contains(extention,StringComparer.OrdinalIgnoreCase);
				if (! isAllowed)
				{
					return new ValidationResult(errorMessage: $"only {_allowedExtensions} are allowed!");
				}
			}
			return ValidationResult.Success;
		}

	}
}
