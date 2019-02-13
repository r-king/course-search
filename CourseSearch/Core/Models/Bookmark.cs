namespace CourseSearch.Core.Models
{
	public class Bookmark
	{
		public Course Course { get; set; }

		public ApplicationUser User { get; set; }

		public int CourseId { get; set; }

		public string UserId { get; set; }
	}
}