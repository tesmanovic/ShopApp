using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    [Table("Order")]
    public class DOrder
    {
       [Key]
        public int Id{ get; set; }
        [Column(TypeName ="NVARCHAR(150)")]
        public string BillingAddress { get; set; }
        [Column(TypeName ="DATETIME")]
        public DateTime OpenDate { get; set; }
        [Column(TypeName ="DATETIME")]
        public DateTime? CloseDate { get; set; }
        [Column(TypeName ="DECIMAL(18,2)")]
        public decimal TotalAmount { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public DCustomer Customer { get; set; }
        [Required]
        public int OrderStatusId { get; set; }
        [ForeignKey("OrderStatusId")]
        public DOrderStatus OrderStatus { get; set; }
        public ICollection<DOrderItem> OrderItems { get; set; }

    }
}
