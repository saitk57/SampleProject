using Microsoft.AspNetCore.Mvc;
using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Controllers
{
    public class KategoriController : Controller
    {
        Context c = new Context();

        public IActionResult Index()
        {
            var kategori = c.Categories.Where(x => x.Durum == true).ToList();
            return View(kategori);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddCategory(Category category)
        {
            c.Categories.Add(category);
            c.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public IActionResult UpdateCategory(int id)
        {
            var kategori = c.Categories.Find(id);
            return View(kategori);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category ctg)
        {
            var ktg = c.Categories.Find(ctg.Id);
            ktg.Name = ctg.Name;
            ktg.Durum = ctg.Durum;
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            var deger = c.Categories.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
