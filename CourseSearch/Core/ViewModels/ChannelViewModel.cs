namespace CourseSearch.Core.ViewModels
{
	/// <summary>
	/// view model to show channel in drop down list	
	/// </summary>
	public class ChannelViewModel
	{
		/// <summary>
		/// channel id
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// channel name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// true if course is in channel
		/// </summary>
		public bool Selected { get; set; }
	}
}