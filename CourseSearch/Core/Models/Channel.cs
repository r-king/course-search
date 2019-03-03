using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

		public ICollection<ChannelCourse> ChannelCourses { get; set; }

		public Channel()
		{
			ChannelCourses = new Collection<ChannelCourse>();
		}

		public void Modify(string name, string description)
		{
			Name = name;
			Description = description;
		}
	}
}