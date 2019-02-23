using CourseSearch.Core.Models;
using CourseSearch.Core.Repositories;
using System;

namespace CourseSearch.Persitence.Repositories
{
	public class PublisherRepository : IPublisherRepository
	{
		private readonly ApplicationDbContext context;

		public PublisherRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public Publisher GetPublisher(int id)
		{
			return context.Publisher.Find(id);
		}
	}
}