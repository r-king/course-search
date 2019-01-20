using System.ComponentModel.DataAnnotations;

namespace CourseSearch.ViewModels
{
	public class ForgotViewModel
	{
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}