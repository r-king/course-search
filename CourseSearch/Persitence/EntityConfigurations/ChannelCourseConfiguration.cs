using CourseSearch.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace CourseSearch.Persitence.EntityConfigurations
{
	public class ChannelCourseConfiguration : EntityTypeConfiguration<ChannelCourse>
	{
		public ChannelCourseConfiguration()
		{
			HasKey(c => new { c.ChannelId, c.CourseId });
		}
	}
}