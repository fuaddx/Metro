using MetroMvc.Contexts;
using MetroMvc.ViewModels.SettingVm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MetroMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SettingController : Controller
    {
        DatadbContext _db { get; set; }
        IWebHostEnvironment _environment;

        public SettingController(DatadbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }
        public async Task<IActionResult> Index() {
            return View(await _db.Settings.Select(c => new SettingListItemVm
            {
                Id = c.Id,
                ImageUrl = c.ImageUrl,
                UpdatedTime = c.UpdatedTime
                
            }).ToListAsync());
        }
        public async Task<IActionResult> Cancel()
        {
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult>Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Settings.FindAsync(id);
            if(data == null) return NotFound();
            return View(new SettingUpdateVm
            {
                ImageUrl = data.ImageUrl,
            });
        }
        [HttpPost]
        public async Task<IActionResult>Update(int? id,SettingUpdateVm vm)
        {
            if (id == null) return BadRequest();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var data = await _db.Settings.FindAsync(id);
            if (data == null) return NotFound();
            if(!string.IsNullOrEmpty(data.ImageUrl))
            {
                string filepath = Path.Combine(_environment.WebRootPath, "Assets", "images", "stories", data.ImageUrl);
                if(System.IO.File.Exists(filepath))
                {
                    System.IO.File.Delete(filepath);
                }
            }
            string filename = Guid.NewGuid() + Path.GetExtension(vm.MainImage.FileName);
            using (Stream fs = new FileStream(Path.Combine(_environment.WebRootPath, "Assets", "images", "stories", filename), FileMode.Create))
            {
                await vm.MainImage.CopyToAsync(fs);
            }
            data.ImageUrl = filename;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult>Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Settings.FindAsync(id);
            if (data == null) return NotFound();
            _db.Settings.Remove(data);
            await _db.SaveChangesAsync();
            return  RedirectToAction(nameof(Index));

        }
    }
}
