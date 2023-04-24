using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace SampleProject.Controllers
{

    public class DenemeController : Controller
    {
        Context c = new Context();

        public IActionResult CategoryIndex()
        {
            var categories = c.Categories.ToList();
            return View(categories);
        }

        public IActionResult SubCategoryIndex()
        {
            var subcategories = c.SubCategories.ToList();
            return View(subcategories);
        }

        public IActionResult ProductIndex()
        {
            var products = c.Products.ToList();
            return View(products);
        }

        public IActionResult CascadeList()
        {
            ViewBag.Categories = new SelectList(c.Categories, "Id", "Name");
            return View();
        }

        public JsonResult LoadSubCategory(int id)
        {
            var subcategory = c.SubCategories.Where(z => z.CategoryId == id).ToList();
            return Json(new SelectList(subcategory, "Id", "Name"));
        }

        public JsonResult LoadProduct(int id)
        {
            var product = c.Products.Where(z => z.SubCategoryId == id).ToList();
            return Json(new SelectList(product, "Id", "Name"));
        }

        public IActionResult ProductList2()
        {
            var liste = c.Products.Include(x => x.SubCategory.Category).ToList();
            return View(liste);
        }
    }   

        
}

   

