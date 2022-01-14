using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HouseOfStories_Models;
using HouseOfStories_DataAccess.Data;
using HouseOfStories_DataAccess.Repository.IRepository;

namespace HouseOfStories.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _catRepo;
        public CategoryController(ICategoryRepository catRepo)
        {
            _catRepo = catRepo;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objList = _catRepo.GetAll();
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
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _catRepo.Add(obj);
                _catRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj =  _catRepo.Find((int)id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _catRepo.Update(obj);
               _catRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            var obj =  _catRepo.Find((int)id);
            if (obj == null)
            {
                return NotFound();
            }
            _catRepo.Remove(obj);
           _catRepo.Save();
            return RedirectToAction(nameof(Index)); 
        }

    }
}
