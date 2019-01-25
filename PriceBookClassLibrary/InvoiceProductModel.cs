using System;

namespace PriceBookClassLibrary
{
    public class InvoiceProductModel
    {
    	public int Id { get; set; }
        public int Weight {get; set;}
        public int Quantity {get; set;}
        public decimal TotalPrice {get; set;}
        public int ProductId {get; set;}
        public string ProductName {get; set;}
        public string ProductLinkName {get; set;}
        public string CategoryName {get; set;}
        public int InvoiceId {get; set;}
        public string InvoiceNumber { get; set; }
        public string InvoiceDate {get; set;}
        public string Sale { get; set; }        
    }
}
