namespace CourseSearch.Migrations
{
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<CourseSearch.Persitence.ApplicationDbContext>
	{
		public Configuration()
		{
			MigrationsDirectory = @"Persitence\Migrations";
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(CourseSearch.Persitence.ApplicationDbContext context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method
			//  to avoid creating duplicate seed data.
		}
	}
}