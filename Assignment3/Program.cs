using System;
using System.Collections.Generic;
namespace PrepareBill1
{
    enum CommodityCategory
    {
        Furniture,
        Grocery,
        Service
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var commodities = new List<Commodity>()
            {
                new Commodity(CommodityCategory.Furniture, "Bed", 2, 50000),
                new Commodity(CommodityCategory.Grocery, "Flour", 5, 80),
                new Commodity(CommodityCategory.Service, "Insurance", 8, 8500),
            };

            var prepareBill = new PrepareBill();
            prepareBill.SetTaxRates(CommodityCategory.Furniture, 18);
            prepareBill.SetTaxRates(CommodityCategory.Grocery, 5);
            prepareBill.SetTaxRates(CommodityCategory.Service, 12);

            var billAmount = prepareBill.CalculateBillAmount(commodities);
            Console.WriteLine($"{billAmount}");
        }
    }
    class Commodity
    {
        public CommodityCategory Category;
        public string CommodityName { get; set; }
        public int CommodityQuantity { get; set; }
        public double CommodityPrice { get; set; }
        public Commodity(CommodityCategory category, string commodityName, int commodityQuantity, double commodityPrice)
        {
            this.Category = category;
            this.CommodityName = commodityName;
            this.CommodityPrice = commodityPrice;
            this.CommodityQuantity = commodityQuantity;
        }
    }
    class PrepareBill
    {
        private readonly IDictionary<CommodityCategory, double> _taxRates;
        public PrepareBill()
        {
            _taxRates = new Dictionary<CommodityCategory, double>();
        }
        public void SetTaxRates(CommodityCategory category, double taxRate)
        {
            _taxRates.Add(category, taxRate);
        }
        public double CalculateBillAmount(List<Commodity> items)
        {
            double res = 0;
            foreach (var i in items)
            {
                double taxRate = _taxRates.ContainsKey(i.Category) ? _taxRates[i.Category] : 0;
                double totalItems = i.CommodityQuantity * i.CommodityPrice;
                double tax = totalItems * (taxRate / 100);
                res += totalItems + tax;
            }
            return res;
        }
    }
}
