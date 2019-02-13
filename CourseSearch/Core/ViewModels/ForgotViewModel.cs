﻿using System.ComponentModel.DataAnnotations;

namespace CourseSearch.Core.ViewModels
{
	public class ForgotViewModel
	{
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}