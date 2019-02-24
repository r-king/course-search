namespace CourseSearch.Core.Models
{
	public class ChannelCourse
	{
		public Channel Channel { get; set; }

		public Course Course { get; set; }

		public int ChannelId { get; set; }

		public int CourseId { get; set; }
	}
}