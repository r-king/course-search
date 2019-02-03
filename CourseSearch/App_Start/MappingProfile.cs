using AutoMapper;
using CourseSearch.Dtos;
using CourseSearch.Models;

namespace CourseSearch.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Course, CourseDto>();
			CreateMap<Publisher, PublisherDto>();
		}
	}
}