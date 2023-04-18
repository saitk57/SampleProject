using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name = "Ad")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name = "Açıklama")]
        [StringLength(50, ErrorMessage = "Max 100 karakter olmalıdır.")]

        public string Description { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name = "Fiyat")]

        public decimal Price { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name = "AltKategori")]

        public int SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
