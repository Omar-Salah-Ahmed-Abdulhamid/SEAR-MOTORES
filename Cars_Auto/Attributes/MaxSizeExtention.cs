using System.ComponentModel.DataAnnotations;

namespace Cars_Auto.Attributes
{
	public class MaxSizeExtention:ValidationAttribute
	{
		private readonly int _MaxSizeFile;

		public MaxSizeExtention(int maxSizeFile)
		{
			_MaxSizeFile = maxSizeFile;
		}

		protected override ValidationResult? IsValid
		  (object? value, ValidationContext validationContext)
		{
			var file= value as IFormFile;
			if(file is not null)
			{
				if (file.Length > _MaxSizeFile)
				{
					return new ValidationResult(errorMessage:$"Max Size must be {_MaxSizeFile}bytes.");
				}
			}
			return ValidationResult.Success;
		}
		}
}
