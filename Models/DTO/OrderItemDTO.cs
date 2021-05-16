using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShopApp.Models.DTO
{
    public class OrderItemDTO
    {
        [JsonPropertyName("IdCustomer")]
        public int IdCustomer { get; set; }
        public List<DOrderItem> Items { get; set; }
    }
}
