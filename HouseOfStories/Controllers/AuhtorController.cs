using HouseOfStories.Data;
using HouseOfStories.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseOfStories.Controllers
{
    public class AuhtorController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AuhtorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Author> objList = _db.Authors;
            return View(objList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author obj)
        {
            if (ModelState.IsValid)
            {
                await _db.Authors.AddAsync(obj);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }
        //GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = await _db.Authors.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Author obj)
        {
            if (ModelState.IsValid)
            {
                _db.Authors.Update(obj);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        //GET
        public async Task<IActionResult> Delete(int? id)
        {
            var obj = await _db.Authors.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Authors.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
