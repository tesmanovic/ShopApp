using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    [Table("OrderStatus")]
    public class DOrderStatus
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="NVARCHAR(20)")]
        public string Description { get; set; }
    }
}
