using CourseSearch.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace CourseSearch.Persitence.EntityConfigurations
{
	public class CourseConfiguration : EntityTypeConfiguration<Course>
	{
		public CourseConfiguration()
		{
			HasMany(c => c.Bookmarks)
				.WithRequired()
				.HasForeignKey(c => c.CourseId);
		}
	}
}