﻿using System.ComponentModel.DataAnnotations;

namespace CourseSearch.Core.ViewModels
{
	public class ExternalLoginConfirmationViewModel
	{
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}