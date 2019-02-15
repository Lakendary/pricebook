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
                    "Invoice.Id, " +
                    "Invoice.InvoiceNumber, " +
                    "Invoice.Saved, "+
                    "Invoice.Date, "+
                    "Invoice.InvoiceAmount, "+
                    "Store.Name StoreName, "+
                    "Invoice.StoreId, " +
                    "Invoice.Deleted " +
                "FROM Invoice " +
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
                    "Store.Name StoreName, " +
                    "Invoice.Deleted "+
                "FROM Invoice "+
                "LEFT JOIN Store "+
                "ON Invoice.StoreId = Store.Id "+
                "WHERE Invoice.Id = @Id", new { Id = id}).FirstOrDefault();
                return output;
            }
        }
        //3. Save To DB
        public static int SaveInvoice(InvoiceModel invoice)
        {
            var id = 0;
            try{
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    id = cnn.Query<int>("INSERT INTO Invoice "+
                    "(Date, InvoiceAmount, InvoiceNumber, Saved, StoreId) "+
                    "VALUES (@Date, @InvoiceAmount, @InvoiceNumber, @Saved, @StoreId);" +
                    "SELECT last_insert_rowid();", invoice).Single();
                }
            } 
            catch(Exception ex){
                General.LogError(ex);
                return id;
            }
            return id;
        }
        //4. Update By Id
        public static bool UpdateInvoiceById(InvoiceModel invoice)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var count = cnn.Execute("UPDATE Invoice "+
                    "SET Date=@Date, InvoiceAmount=@InvoiceAmount, "+
                    "InvoiceNumber=@InvoiceNumber, Saved=@Saved, StoreId=@StoreId"+
                    "WHERE Invoice.Id = @Id", invoice);
                return count > 0;
            }
        }
        //5. Delete By Id - OPEN INVOICE
        public static bool DeleteOpenInvoiceById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var affectedRows = cnn.Execute("DELETE FROM Invoice "+
                    "WHERE Id= @Id", new {Id = id});
                return affectedRows > 0;
            }
        }

        //6. Delete By Id - SAVED INVOICE
        public static bool DeleteSavedInvoiceById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var affectedRows = cnn.Execute("UDPATE Invoice " +
                    "SET Deleted='Deleted' " +
                    "WHERE Id= @Id", new { Id = id });
                return affectedRows > 0;
            }
        }
    }
}
