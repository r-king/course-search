using CourseSearch.Core.Models;
using CourseSearch.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CourseSearch.Persitence.Repositories
{
	public class ChannelRepository : IChannelRepository
	{
		private readonly ApplicationDbContext context;

		public ChannelRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public void Create(Channel channel)
		{
			context.Channels.Add(channel);
		}

		public void Remove(Channel channel)
		{
			context.Channels.Remove(channel);
		}

		public IEnumerable<Channel> GetUserChannels(string userId)
		{
			return context.Channels
				.Include(c => c.ChannelCourses.Select(h => h.Course))
				.Where(c => c.UserId == userId)
				.OrderBy(c => c.Name);
		}

		public Channel GetChannel(int id)
		{
			return context.Channels
				.FirstOrDefault(c => c.Id == id);
		}

		public Channel GetUserChannelByName(string userId, string name)
		{
			return context.Channels
				.FirstOrDefault(c => c.UserId == userId && c.Name == name);
		}
	}
}