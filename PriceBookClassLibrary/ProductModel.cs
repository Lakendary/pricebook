using System;

namespace PriceBookClassLibrary
{
    public class ProductModel
    {
    	public int Id { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string PackSize { get; set; }
        public string UoM { get; set; }
        public int ProductLinkId { get; set; }
        public string ProductLinkName { get; set; }
        public string CategoryName { get; set; }
    }
}