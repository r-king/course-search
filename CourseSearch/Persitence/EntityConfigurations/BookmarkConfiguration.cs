using CourseSearch.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace CourseSearch.Persitence.EntityConfigurations
{
	public class BookmarkConfiguration : EntityTypeConfiguration<Bookmark>
	{
		public BookmarkConfiguration()
		{
			HasKey(a => new { a.CourseId, a.UserId });
		}
	}
}