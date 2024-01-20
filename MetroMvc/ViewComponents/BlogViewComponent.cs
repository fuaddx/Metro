using MetroMvc.Contexts;
using MetroMvc.ViewModels.BlogVm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MetroMvc.ViewComponents
{
    public class BlogViewComponent:ViewComponent
    {
        DatadbContext _db {  get; set; }

        public BlogViewComponent(DatadbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _db.Blogs.Select(c => new BlogListItemVm
            {
                Id = c.Id,
                Button = c.Button,
                UpdatedTime = c.UpdatedTime,
                CreatedTime = c.CreatedTime,
                Date = c.Date,
                IsDeleted = c.IsDeleted,
            }).ToListAsync());
        }
    }
}
