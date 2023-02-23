using CarsTestTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarsTestTask.Controllers
{
    public class GroupByBrandController : Controller
    {
        Context db;
        public GroupByBrandController(Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var brands = db.Brands.ToList();
            var models = db.Models.ToList();
            var sort = models.GroupBy(criteria => criteria.BrandID)
                .Select(s => (brands.FirstOrDefault(f => f.Id == s.Key)?.Name ?? "Без бренда", s.ToList())).ToList();
            return View(sort);
        }
    }
}
