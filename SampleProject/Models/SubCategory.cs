
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public  int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public List<Product> Products { get; set; }
    }
}
