using MetroMvc.Contexts;
using MetroMvc.Models;
using MetroMvc.ViewModels.BlogVm;
using MetroMvc.ViewModels.DescriptionVm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MetroMvc.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DescriptionController : Controller
	{
		DatadbContext _db { get; set; }

		public DescriptionController(DatadbContext db)
		{
			_db = db;
		}
		public async Task<IActionResult> Index()
		{
			return View(await _db.Descriptions.Select(c => new DescriptionListItemVm
			{
				Id = c.Id,
				Descriptionn = c.Descriptionn,
				Blog = c.Blog,
				UpdatedTime = c.UpdatedTime,
				CreatedTime = c.CreatedTime,
			}).ToListAsync());
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
		public async Task<IActionResult> Create(BlogCreateVm vm)
		{
			if (!ModelState.IsValid)
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
		public async Task<IActionResult> Update(int? id)
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
		public async Task<IActionResult> Update(int? id, BlogUpdateVm vm)
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
