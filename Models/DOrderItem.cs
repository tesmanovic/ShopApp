using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    [Table("OrderItem")]
    public class DOrderItem
    {
        [Key]
        
        public int Id { get; set; }
        [Column(TypeName = "INT")]
        [JsonPropertyName("OrderNumber")]
        public int OrderNumber { get; set; }
        [Column(TypeName ="DECIMAL(18,2)")]
        [JsonPropertyName("Amount")]
        public double  Amount { get; set; }
        [Column(TypeName ="INTEGER")]
        [JsonPropertyName("Quantity")]

        public int Quantity { get; set; }
        [JsonPropertyName("OrderId")]

        [ForeignKey("OrderId")]
        [Required]
        public int OrderId { get; set; }
        public DOrder Order { get; set; }
        [JsonPropertyName("TicketId")]
        [ForeignKey("TicketId")]
        [Required]
        public int TicketId { get; set; }

        public DTicket Ticket { get; set; }
       

    }
}
