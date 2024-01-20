using MetroMvc.Models;

namespace MetroMvc.ViewModels.DescriptionVm
{
	public class DescriptionListItemVm
	{
		public int Id { get; set; }
		public DateTime? UpdatedTime { get; set; }
		public string Descriptionn { get; set; }
		public DateTime? CreatedTime { get; set; }
		public int BlogId { get; set; }
		public Blog? Blog { get; set; }
	}
}
