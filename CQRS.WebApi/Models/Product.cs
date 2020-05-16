using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.WebApi.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public decimal BuyingPrice { get; set; }
        public string ConfidentialData { get; set; }
    }
}
