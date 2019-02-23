using CourseSearch.Core.Models;

namespace CourseSearch.Core.Repositories
{
	public interface IPublisherRepository
	{
		Publisher GetPublisher(int id);
	}
}