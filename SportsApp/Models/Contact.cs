using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsApp.Models
{
    [Table(name: "Contacts")]

    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string FullName { get; set; }    
        public string Email { get; set; }

        public string PhoneNumber{ get; set; }

        public  string Messege { get; set; }
    }
}
