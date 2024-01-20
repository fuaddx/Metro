using MetroMvc.Contexts;
using MetroMvc.Models;
using MetroMvc.ViewModels.BlogVm;
using MetroMvc.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MetroMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class BlogController : Controller
    {
		DatadbContext _db {  get; set; }

		public BlogController(DatadbContext db)
		{
			_db = db;
		}

       /* public async Task<IActionResult> Index()
        {
            return View(await _db.Blogs.Select(c =>new BlogListItemVm
            {
                Id = c.Id,
                Button = c.Button,
                UpdatedTime = c.UpdatedTime,
                CreatedTime = c.CreatedTime,
                Date = c.Date,
                IsDeleted = c.IsDeleted,
            }).ToListAsync());
        }*/
       public async Task<IActionResult> Index()
        {
            int take = 4;
            var items = await _db.Blogs.Take(take).Select(c => new BlogListItemVm
            {
                Id = c.Id,
                Button = c.Button,
                UpdatedTime = c.UpdatedTime,
                CreatedTime = c.CreatedTime,
                Date = c.Date,
                IsDeleted = c.IsDeleted,
            }).ToListAsync();
            int count = await _db.Blogs.CountAsync();
            PaginationVm<IEnumerable<BlogListItemVm>>pag = new(count,1,(int)Math.Ceiling((decimal)count/take),items);
            return View(pag);
        }
        public async Task<IActionResult>ProductPagination(int page=1, int count = 8)
        {
            var items = await _db.Blogs.Skip((page - 1) * count).Take(count).Select(c => new BlogListItemVm
            {
                Id = c.Id,
                Button = c.Button,
                UpdatedTime = c.UpdatedTime,
                CreatedTime = c.CreatedTime,
                Date = c.Date,
                IsDeleted = c.IsDeleted,
            }).ToListAsync();
            int totalcount = await _db.Blogs.CountAsync();
            PaginationVm<IEnumerable<BlogListItemVm>>pag = new(totalcount,page,(int)Math.Ceiling((decimal)totalcount/count),items);
            return PartialView("ProductPagination", pag);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        public async Task<IActionResult> Cancel()
        {
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult>Create(BlogCreateVm vm)
        {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }
            Blog blog = new Blog()
            {
                Date = vm.Date,
                Button = vm.Button,
            };
            _db.Blogs.AddAsync(blog);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult>Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Blogs.FindAsync(id);
            if (data == null) return NotFound();
            return View(new BlogUpdateVm
            {

                Button = data.Button,
                Date = data.Date,
            });
        }
        [HttpPost]
        public async Task<IActionResult>Update(int? id, BlogUpdateVm vm)
        {
            if (id == null) return BadRequest();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
			var data = await _db.Blogs.FindAsync(id);
			if (data == null) return NotFound();
            data.Date = vm.Date;
            data.Button = vm.Button;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
		}
        public async Task<IActionResult>DeleteProduct(int? id)
        {
			if (id == null) return BadRequest();
			var data = await _db.Blogs.FindAsync(id);
			if (data == null) return NotFound();
            data.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> RestoreProduct(int? id)
		{
			if (id == null) return BadRequest();
			var data = await _db.Blogs.FindAsync(id);
			if (data == null) return NotFound();
			data.IsDeleted = false;
			await _db.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> DeleteFromData(int? id)
		{
			if (id == null) return BadRequest();
			var data = await _db.Blogs.FindAsync(id);
			if (data == null) return NotFound();
			_db.Blogs.Remove(data);
			await _db.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
