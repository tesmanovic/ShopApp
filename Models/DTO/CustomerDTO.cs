using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopApp.Models.DTO
{
    public class CustomerDTO
    {
        [JsonPropertyName("Username")]
        public string Username { get; set; }
        [JsonPropertyName("Password")]
        public string Password { get; set; }
        public DCustomer customer { get; set; }
    }
}
