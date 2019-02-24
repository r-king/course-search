using CourseSearch.Core.Models;
using System.Collections.Generic;

namespace CourseSearch.Core.Repositories
{
	public interface IChannelRepository
	{
		void Create(Channel channel);

		void Remove(Channel channel);

		Channel GetChannel(int id);

		IEnumerable<Channel> GetUserChannels(string userId);

		Channel GetUserChannelByName(string userId, string name);
	}
}