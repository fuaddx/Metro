namespace MetroMvc.Models
{
	public class Blog:BaseEntity
	{
        public string Date { get; set; }
        public string Button { get; set; }
        public DateTime? CreatedTime { get; set; }
        public bool  IsDeleted { get; set; }
        public IEnumerable<Description> Descriptions {  get; set; }
    }
}
