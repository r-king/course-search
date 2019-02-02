using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CourseSearch.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<Course> Courses { get; set; }

		public DbSet<Publisher> Publisher { get; set; }

		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}