using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SportsApp.Models
{
    [Table(name: "BookingDetails")]
    public class BookingDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }



        [Display(Name = "Select Product")]
        public int ProductId { get; set; }

        [ForeignKey(nameof(BookingDetail.ProductId))] //mapping foreign key
        public Product Product { get; set; }


        public string UserName { get; set; }


        [Required]
        [Display(Name = "Select Quantity")]

        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Enter Your Mobile Number")]
        public string MoibileNumber { get; set; }



        [Required]
        [Display(Name = "Enter Delevery Address")]
        public string UserAddress { get; set; }
    }
}
