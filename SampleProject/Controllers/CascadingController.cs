using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Controllers
{
    

    public class CascadingController : Controller
    {
        Context c = new Context();

        public IActionResult Index()
        {
            ViewBag.CategoryList = new SelectList(GetCategoryList(), "Id", "Name");
            return View();
        }

        public List<Category> GetCategoryList()
        {
            List<Category> Categories = c.Categories.ToList();
            return Categories;
        }

        public IActionResult GetSubCategoryList(int KategoriID)
        {
            List<SubCategory> subcategories = c.SubCategories.Where(x => x.CategoryId == KategoriID).ToList();
            ViewBag.SubCategoryList = new SelectList(subcategories, "Id", "Name");
            return PartialView("DisplaySubCategories");
        }

        public IActionResult GetProductList(int AltKategoriID)
        {
            List<Product> products = c.Products.Where(x => x.SubCategoryId == AltKategoriID).ToList();
            ViewBag.productList = new SelectList(products, "Id", "Name");
            return PartialView("DisplayProducts");
        }
    }
}
