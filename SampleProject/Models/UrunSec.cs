using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Models
{
    public class UrunSec
    {
        public int SelectedCategoriesId  { get; set; }

        public List<Category> CategoriesList { get; set; }

        public List<Product> Product { get; set; }

    }
}
