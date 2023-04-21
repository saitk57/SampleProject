using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Models
{
    public class Category
    
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Durum { get; set; }

        public List<SubCategory> SubCategories { get; set; }


    }
}
