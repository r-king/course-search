using CourseSearch.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace CourseSearch.Persitence.EntityConfigurations
{
	public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
	{
		public ApplicationUserConfiguration()
		{
			HasMany(a => a.Bookmarks)
				.WithRequired()
				.HasForeignKey(a => a.UserId);

			HasMany(a => a.Channels)
				.WithRequired()
				.HasForeignKey(a => a.UserId);
		}
	}
}