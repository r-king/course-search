using System.ComponentModel.DataAnnotations;

namespace CourseSearch.Core.ViewModels
{
	public class ForgotPasswordViewModel
	{
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}