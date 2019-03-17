namespace PriceBookClassLibrary
{
    public class InvoiceModel
    {
    	public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string Saved { get; set; }
        public int StoreId {get; set;}
        public string StoreName {get; set;}
        public string Date {get; set;}
        public decimal InvoiceAmount {get; set;}
        public string Deleted { get; set; }
    }
}
