using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    [Table("ShoppingCart")]
    public class DShoppingCart
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="DATETIME")]
        public DateTime CreateDate { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public DCustomer Customer { get; set; }
    }
}
