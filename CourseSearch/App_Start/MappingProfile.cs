using AutoMapper;
using CourseSearch.Core.Dtos;
using CourseSearch.Core.Models;

namespace CourseSearch.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Course, CourseDto>();
			CreateMap<Publisher, PublisherDto>();
			CreateMap<Channel, ChannelDto>();
			CreateMap<ChannelCourse, ChannelCourseDto>();
		}
	}
}