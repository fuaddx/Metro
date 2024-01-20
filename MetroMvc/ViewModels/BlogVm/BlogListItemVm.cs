using MetroMvc.Models;

namespace MetroMvc.ViewModels.BlogVm
{
	public class BlogListItemVm
	{
		public int Id { get; set; }
		public DateTime? UpdatedTime { get; set; }
		public string Date { get; set; }
		public string Button { get; set; }
		public DateTime? CreatedTime { get; set; }
		public bool IsDeleted { get; set; }
		public IEnumerable<Description> Descriptions { get; set; }
	}
}
