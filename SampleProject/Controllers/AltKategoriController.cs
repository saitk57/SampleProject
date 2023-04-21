using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SampleProject.Controllers
{
    public class AltKategoriController : Controller
    {
        Context c = new Context();

        public IActionResult Index()
        {
            var altkategori = c.SubCategories.Include(x => x.Category).Where(x => x.Durum == true).ToList();
            
            return View(altkategori);
        }

        public IActionResult AddSubCategory()
        {
            List<SelectListItem> degerler = (from x in c.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.Id.ToString()

                                             }).ToList();

            ViewBag.dgr = degerler;
            return View();

        }

        [HttpPost]
        public IActionResult AddSubCategory(SubCategory sub)
        {
            var Altkategori = c.Categories.Where(x => x.Id == sub.Category.Id).FirstOrDefault();
            sub.Category = Altkategori;

            c.SubCategories.Add(sub);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult UpdateSubCategory(int id)
        {
            List<SelectListItem> degerler = (from x in c.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.Id.ToString()

                                             }).ToList();

            ViewBag.dgr = degerler;
            var Altkategori = c.SubCategories.Find(id);
            return View(Altkategori);

        }

        [HttpPost]

        public IActionResult UpdateSubCategory(SubCategory sub)
        {
            var subcategory = c.SubCategories.Find(sub.Id);
            var Altkategori = c.Categories.Where(x => x.Id == sub.Category.Id).FirstOrDefault();
            subcategory.Category = Altkategori;
            subcategory.Name = sub.Name;
            subcategory.Durum = sub.Durum;

            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult DeleteSubCategory(int id)
        {
            var deger = c.SubCategories.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
