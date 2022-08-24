using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;
using System.Collections.Generic;

namespace SportsApp.Models
{
    [Table(name: "Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }  


       

        [Required]
        public string ImgUrl { get; set; }

        [Required]
        public string BrandName { get; set; }

        [Required]
        public string SellerName { get; set; }

        [Required]
        [Display(Name ="Price Per Item")]
        public decimal Price { get; set; }

        [Required]
        [DefaultValue(false)]
        public int NumberOfProducts { get; set; }


        [Display(Name = "Select Sports Category")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(Product.CategoryId))]

        public Category Category { get; set; }

        public List<BookingDetail> BookingDetails { get; set; }









    }
}
