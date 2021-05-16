using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    [Table("Ticket")]
    public class DTicket
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="DECIMAL(18,2)")]
        public double Price { get; set; }
        [Column(TypeName ="DATETIME")]
        public DateTime DateFrom { get; set; }
        [Column(TypeName ="DATETIME")]
        public DateTime ExpirationDate { get; set; }
        [ForeignKey("StageId")]
        [Required]
        public int StageId { get; set; }
        public DStage Stage { get; set; }

    }
}
