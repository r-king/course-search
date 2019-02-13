using System.Collections.Generic;

namespace CourseSearch.Core.ViewModels
{
	public class ConfigureTwoFactorViewModel
	{
		public string SelectedProvider { get; set; }
		public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
	}
}