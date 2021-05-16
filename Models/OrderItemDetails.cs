using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    public class OrderItemDetails
    {
        [Column(TypeName = "INT")]
        [JsonPropertyName("OrderNumber")]
        public int OrderNumber { get; set; }
        [Column(TypeName = "DECIMAL(18,2)")]
        [JsonPropertyName("Amount")]
        public double Amount { get; set; }
        [Column(TypeName = "INTEGER")]
        [JsonPropertyName("Quantity")]

        public int Quantity { get; set; }
        
        [JsonPropertyName("TicketId")]
        public int TicketId { get; set; }
        public double Price { get; set; }
        public string StageName { get; set; }

    }
}
