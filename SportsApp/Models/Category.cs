using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SportsApp.Models
{
    [Table(name: "Categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CategoryId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Enter Sports Category")]
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }//A list of pruducts that a category can hold multiple products






    }
}
