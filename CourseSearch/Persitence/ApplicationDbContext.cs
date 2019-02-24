using CourseSearch.Core.Models;
using CourseSearch.Persitence.EntityConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;

namespace CourseSearch.Persitence
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<Course> Courses { get; set; }

		public DbSet<Publisher> Publisher { get; set; }

		public DbSet<Bookmark> Bookmarks { get; set; }

		public DbSet<Channel> Channels { get; set; }

		public DbSet<ChannelCourse> ChannelCourses { get; set; }

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
			modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
			modelBuilder.Configurations.Add(new ChannelConfiguration());
			modelBuilder.Configurations.Add(new ChannelCourseConfiguration());

			base.OnModelCreating(modelBuilder);
		}

		public override int SaveChanges()
		{
			foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
			{
				// set date created for channel
				if (typeof(Channel).IsAssignableFrom(entry.Entity.GetType()) && (DateTime)entry.Property("DateCreated").CurrentValue == DateTime.MinValue)
					entry.Property("DateCreated").CurrentValue = DateTime.Now;
			}

			return base.SaveChanges();
		}
	}
}