using System;

namespace PriceBookClassLibrary
{
    public class ProductLinkModel
    {
    	public int Id { get; set; }
        public string Name { get; set; }
        public string UoM { get; set; }
        public string Weighted { get; set; }
        public int MeasurementRate { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}