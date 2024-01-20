namespace MetroMvc.Models
{
	public class Description:BaseEntity
	{
        public string Descriptionn { get; set; }
		public DateTime? CreatedTime { get; set; }
		public int BlogId { get; set; }
        public Blog? Blog { get; set; }
    }
}
