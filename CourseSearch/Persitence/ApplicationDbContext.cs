using CourseSearch.Core.Models;
using CourseSearch.Persitence.EntityConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CourseSearch.Persitence
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<Course> Courses { get; set; }

		public DbSet<Publisher> Publisher { get; set; }

		public DbSet<Bookmark> Bookmarks { get; set; }

		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new BookmarkConfiguration());		
			modelBuilder.Configurations.Add(new CourseConfiguration());
			
			base.OnModelCreating(modelBuilder);
		}
	}
}