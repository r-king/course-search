using CourseSearch.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace CourseSearch.Persitence.EntityConfigurations
{
	public class ChannelConfiguration : EntityTypeConfiguration<Channel>
	{
		public ChannelConfiguration()
		{
			Property(a => a.Name).IsRequired().HasMaxLength(100);			
		}
	}
}