using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    [Table("Payment")]
    public class DPayment
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="DATETIME")]
        public DateTime? PaidDate { get; set; }
        [Column(TypeName ="DECIMAL(18,2)")]
        public double TotalAmount { get; set; }
        [ForeignKey("CustomerId")]
        [Required]
        public int CustomerId { get; set; }
        public DCustomer Customer { get; set; }
        [ForeignKey("OrderId")]
        [Required]
        public int OrderId { get; set; }
        public DOrder Order { get; set; }
    }
}
