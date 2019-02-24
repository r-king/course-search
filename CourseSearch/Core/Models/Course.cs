using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CourseSearch.Core.Models
{
	public class Course
	{
		public int Id { get; set; }
		public string PublisherCourseId { get; set; }
		public string Title { get; set; }
		public string ShortDescription { get; set; }
		public string Description { get; set; }
		public int PublisherId { get; set; }
		public Publisher Publisher { get; set; }
		public string Url { get; set; }
		public string ImageUrl { get; set; }
		public DateTimeOffset PublishedOn { get; set; }
		public double Price { get; set; }
		public string CurrencySymbol { get; set; }
		public PaymentType PaymentType { get; set; }

		public ICollection<Bookmark> Bookmarks { get; private set; }

		public ICollection<ChannelCourse> ChannelCourses { get; set; }

		public Course()
		{
			Bookmarks = new Collection<Bookmark>();
			ChannelCourses = new Collection<ChannelCourse>();
		}

		public string GetDisplayDate()
		{
			return PublishedOn.ToString("dd/MM/yyyy");
		}

		public string GetDisplayPrice()
		{
			switch (PaymentType)
			{
				case PaymentType.FREE: return "Free";
				case PaymentType.PAID: return string.Format("{0} {1}", CurrencySymbol, Price);
				case PaymentType.SUBSCRIPTION: return "Subscription";
				default: return "";
			}
		}
	}
}