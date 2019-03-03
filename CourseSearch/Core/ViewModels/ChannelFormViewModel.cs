using CourseSearch.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CourseSearch.Core.ViewModels
{
    public class ChannelFormViewModel
    {
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		public string Description { get; set; }

		public string Heading { get; set; }

		public string ErrorMessage { get; set; }

		public string Action
		{
			get
			{
				Expression<Func<ChannelsController, ActionResult>> update =
					(c => c.Update(this));

				Expression<Func<ChannelsController, ActionResult>> create =
					(c => c.Create(this));

				var action = (Id != 0) ? update : create;

				return (action.Body as MethodCallExpression).Method.Name;
			}
		}
	}
}
