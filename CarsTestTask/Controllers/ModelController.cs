using CarsTestTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarsTestTask.Controllers
{
    public class ModelController : Controller
    {
        Context db;
        public ModelController(Context context)
        {
            db = context;
        }

        private readonly ILogger<ModelController> _logger;

        public IActionResult Create()
        {

            ViewBag.Brand = new SelectList(db.Brands, "Id", "Name"); // ресурс для выпадающего списка
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Index()
        {
            var brands = db.Brands.ToList();
            var models = db.Models.ToList();
            var sort = models
                .Select(s => (brands.FirstOrDefault(f => f.Id == s.BrandID)?.Name ?? "Без бренда", s)).ToList();
            return View(sort);

        }


        [HttpPost] //удаление только пост запросом потому что get небезопасно
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Model? model = await db.Models.FirstOrDefaultAsync(p => p.Id == id);
                if (model != null)
                {
                    db.Models.Remove(model);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Brand = new SelectList(db.Brands, "Id", "Name"); // ресурс для выпадающего списка

            if (id != null)
            {
                Model? model = await db.Models.FirstOrDefaultAsync(p => p.Id == id);
                if (model != null) return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Model model)
        {
            // Brand brand = brands.FirstOrDefault(c => c.Id == model.BrandID);
            db.Models.Add(model);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Model model)
        {
            db.Models.Update(model);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}