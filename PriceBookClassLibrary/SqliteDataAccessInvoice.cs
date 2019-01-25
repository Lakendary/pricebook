using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBookClassLibrary
{
    public class SqliteDAInvoice
    {
        //A. Connection String
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        //1. Get All
        public static List<InvoiceModel> GetAllInvoices()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<InvoiceModel>("SELECT "+
                    "Invoice.InvoiceNumber, "+
                    "Invoice.Saved, "+
                    "Invoice.Date, "+
                    "Invoice.InvoiceAmount, "+
                    "Store.Name StoreName "+
                "FROM Invoice "+
                "LEFT JOIN Store "+
                "ON Invoice.StoreId = Store.Id", new DynamicParameters());
                return output.ToList();
            }
        }
        //2. Get By Id
        public static InvoiceModel GetInvoiceById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<InvoiceModel>("SELECT "+
                    "Invoice.InvoiceNumber, "+
                    "Invoice.Saved, "+
                    "Invoice.Date, "+
                    "Invoice.InvoiceAmount, "+
                    "Store.Name StoreName "+
                "FROM Invoice "+
                "LEFT JOIN Store "+
                "ON Invoice.StoreId = Store.Id "+
                "WHERE Invoice.Id = @Id", new { Id = id}).FirstOrDefault();
                return output;
            }
        }
        //3. Save To DB
        public static bool SaveInvoice(InvoiceModel invoice)
        {
            try{
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("INSERT INTO Invoice "+
                    "(Date, InvoiceAmount, InvoiceNumber, Saved, StoreId) "+
                    "VALUES (@Date, @InvoiceAmount, @InvoiceNumber, '@Saved, @StoreId);", invoice);
                }
            } 
            catch(Exception ex){
                return false;
            }
            return true;
        }
        //4. Update By Id
        public static bool UpdateInvoiceById(InvoiceModel invoice)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var count = this.cnn.Execute("UPDATE Invoice "+
                    "SET Date=@Date, InvoiceAmount=@InvoiceAmount, "+
                    "InvoiceNumber=@InvoiceNumber, Saved=@Saved, StoreId=@StoreId"+
                    "WHERE Invoice.Id = @Id", invoice);
                return count > 0;
            }
        }
        //5. Delete By Id
        public static bool DeleteInvoiceById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var affectedRows = this.cnn.Execute("DELETE FROM Invoice "+
                    "WHERE Id= @Id", new {Id = id});
                return affectedRows > 0;
            }
        }
    }
}
