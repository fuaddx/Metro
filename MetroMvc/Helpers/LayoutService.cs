using MetroMvc.Contexts;
using MetroMvc.Models;

namespace MetroMvc.Helpers
{
	public class LayoutService
	{
		DatadbContext _db {  get; set; }

		public LayoutService(DatadbContext db)
		{
			_db = db;
		}

		public async Task<Setting> GetDatas()
			=> await _db.Settings.FindAsync(1);
	}
}
