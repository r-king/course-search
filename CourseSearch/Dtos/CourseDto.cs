﻿using System;

namespace CourseSearch.Dtos
{
	public class CourseDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTimeOffset PublishedOn { get; set; }
		public PublisherDto Publisher { get; set; }
	}
}