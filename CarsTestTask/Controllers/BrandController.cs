using CarsTestTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsTestTask.Controllers
{
    public class BrandController : Controller
    {

        Context db;
        public BrandController(Context context)
        {
            db = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await db.Brands.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
            db.Brands.Add(brand);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost] //удаление только пост запросом потому что get небезопасно
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Brand? brand = await db.Brands.FirstOrDefaultAsync(p => p.Id == id);
                if (brand != null)
                {
                    db.Brands.Remove(brand);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {

                Brand? brand = await db.Brands.FirstOrDefaultAsync(p => p.Id == id);
                if (brand != null) return View(brand);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Brand brand)
        {
            db.Brands.Update(brand);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
