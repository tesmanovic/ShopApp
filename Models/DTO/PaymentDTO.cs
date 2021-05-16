using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Models.DTO
{
    public class PaymentDTO
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public double Amount { get; set; }
    }
}
