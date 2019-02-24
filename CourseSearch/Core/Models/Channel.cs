using System;

namespace CourseSearch.Core.Models
{
	public class Channel
	{
		public int Id { get; set; }

		public ApplicationUser User { get; set; }

		public string UserId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime DateCreated { get; set; }
	}
}