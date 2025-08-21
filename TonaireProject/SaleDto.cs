using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonaireProject
{
    public class SaleDto
    {
        // Auto implement Prop
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public DateTime SaleDate { get; set; }

        // Prop for Calculating total 
        public double Total => Math.Round(Quantity * UnitPrice, 2);

        // Constructor with param
        public SaleDto(string productCode, string productName, int quantity, double unitPrice, DateTime saleDate)
        {
            ProductCode = productCode;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            SaleDate = saleDate;
        }
    }
}
