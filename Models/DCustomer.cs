using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    [Table("Customer")]
    public class DCustomer
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="NVARCHAR(50)")]
        [JsonPropertyName("Username")]
        public string Username { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        [JsonPropertyName("Password")]

        public string Password { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        [JsonPropertyName("Address")]
        public string Address { get; set; }
        [Column(TypeName ="NVARCHAR(MAX)")]
        [JsonPropertyName("BillingAddress")]
        public string BillingAddress { get; set; }
        [Column(TypeName ="DATETIME")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OpenDate { get; set; }
        [Column(TypeName ="DATETIME")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CloseDate { get; set; }

        public ICollection<DShoppingCart> ShoppingCarts { get; set; }
        public ICollection<DOrder> Orders { get; set; }
        public ICollection<DPayment> Payments { get; set; }
    }
}
