using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace SampleProject.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();

        public IActionResult Index(/*int page=1*/)
        {
            var liste = c.Products.Include(x => x.SubCategory.Category).ToList();/*.ToPagedList(page,10);*/

            return View(liste);
        }

        public IActionResult ProductList()
        {
            var liste = c.Products.Include(x => x.SubCategory.Category).ToList();
            return View(liste);
        }

        public IActionResult AddProduct()
        {
            List<SelectListItem> degerler = (from x in c.SubCategories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.Id.ToString()

                                             }).ToList();

            ViewBag.dgr = degerler;
            return View();

        }

        [HttpPost]

        public IActionResult AddProduct(Product product, AddProductImage p)
        {
            var urn = c.SubCategories.Where(x => x.Id == product.SubCategory.Id).FirstOrDefault();
            product.SubCategory = urn;

            if (p.Image != null)
            {
                var extension = Path.GetExtension(p.Image.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.Image.CopyTo(stream);
                product.Image = newimagename;

            }

            product.Name = p.Name;
            product.Price = p.Price;
            product.Description = p.Description;

            c.Products.Add(product);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateProduct(int id)
        {
            List<SelectListItem> degerler = (from x in c.SubCategories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.Id.ToString()

                                             }).ToList();

            ViewBag.dgr = degerler;
            var urun = c.Products.Find(id);
            return View(urun);
            
        }

        [HttpPost]

        public IActionResult UpdateProduct(Product product, AddProductImage p)
        {
            var urn = c.Products.Find(product.Id);
            var altkategoriid = c.SubCategories.Where(x => x.Id == product.SubCategory.Id).FirstOrDefault();
            urn.SubCategory = altkategoriid;

            if (p.Image != null)
            {
                var extension = Path.GetExtension(p.Image.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.Image.CopyTo(stream);
                urn.Image = newimagename;
                
            }

            urn.Name = p.Name;
            urn.Price = p.Price;
            urn.Description = p.Description;

            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult DeleteProduct(int id)
        {
            var urn = c.Products.Find(id);
            c.Products.Remove(urn);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
