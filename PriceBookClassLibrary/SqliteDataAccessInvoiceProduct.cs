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
    public class SqliteDAInvoiceProduct
    {
        //A. Connection String
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        //1. Get All
        public static List<InvoiceProductModel> GetAllInvoiceProducts()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<InvoiceProductModel>("SELECT "+
                    "InvoiceProduct.Id, " +
                    "Invoice.InvoiceNumber, " +
                    "InvoiceProduct.InvoiceId, " +
                    "Invoice.Date InvoiceDate, " +
                    "Product.Id ProductId, "+
                    "Product.BrandName||' '||Product.Description ProductName, "+
                    "InvoiceProduct.Quantity, "+
                    "InvoiceProduct.Weight, "+
                    "InvoiceProduct.TotalPrice, "+
                    "InvoiceProduct.Sale, "+
                    "ProductLink.Name ProductLinkName, "+
                    "Category.Name CategoryName, " +
                    "ProductLink.UoM, "+
                    "ProductLink.Weighted " +
                "FROM InvoiceProduct " +
                "LEFT JOIN Product "+
                "ON InvoiceProduct.ProductId = Product.Id "+
                "LEFT JOIN Invoice "+
                "ON InvoiceProduct.InvoiceId = Invoice.Id "+
                "LEFT JOIN ProductLink "+
                "ON Product.ProductLinkId = ProductLink.Id "+
                "LEFT JOIN Category "+
                "ON ProductLink.CategoryId = Category.Id", new DynamicParameters());
                return output.ToList();
            }
        }
        //2. Get All by Invoice Id
        public static List<InvoiceProductModel> GetAllInvoiceProductsByInvoiceId(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<InvoiceProductModel>("SELECT " +
                    "InvoiceProduct.Id, "+
                    "Invoice.InvoiceNumber, " +
                    "InvoiceProduct.InvoiceId, "+
                    "Invoice.Date InvoiceDate, "+
                    "Product.Id ProductId, " +
                    "Product.BrandName||' '||Product.Description ProductName, " +
                    "InvoiceProduct.Quantity, "+
                    "InvoiceProduct.Weight, "+
                    "InvoiceProduct.TotalPrice, "+
                    "InvoiceProduct.Sale, "+
                    "ProductLink.Name ProductLinkName, "+
                    "Category.Name CategoryName, "+
                    "ProductLink.UoM, " +
                    "ProductLink.Weighted " +
                "FROM InvoiceProduct " +
                "LEFT JOIN Product "+
                "ON InvoiceProduct.ProductId = Product.Id "+
                "LEFT JOIN Invoice "+
                "ON InvoiceProduct.InvoiceId = Invoice.Id "+
                "LEFT JOIN ProductLink "+
                "ON Product.ProductLinkId = ProductLink.Id "+
                "LEFT JOIN Category "+
                "ON ProductLink.CategoryId = Category.Id "+
                "WHERE Invoice.Id = @Id", new {Id = id});
                return output.ToList();
            }
        }
        //3. Get By Id
        public static InvoiceProductModel GetInvoiceProductById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<InvoiceProductModel>("SELECT "+
                    "InvoiceProduct.Id, " +
                    "Invoice.InvoiceNumber, " +
                    "InvoiceProduct.InvoiceId, " +
                    "Invoice.Date InvoiceDate, " +
                    "Product.Id ProductId, " +
                    "Product.BrandName||' '||Product.Description ProductName, " +
                    "InvoiceProduct.Quantity, "+
                    "InvoiceProduct.Weight, "+
                    "InvoiceProduct.TotalPrice, "+
                    "InvoiceProduct.Sale, "+
                    "ProductLink.Name ProductLinkName, "+
                    "Category.Name CategoryName, "+
                    "ProductLink.UoM, " +
                    "ProductLink.Weighted " +
                "FROM InvoiceProduct " +
                "LEFT JOIN Product "+
                "ON InvoiceProduct.ProductId = Product.Id "+
                "LEFT JOIN Invoice "+
                "ON InvoiceProduct.InvoiceId = Invoice.Id "+
                "LEFT JOIN ProductLink "+
                "ON Product.ProductLinkId = ProductLink.Id "+
                "LEFT JOIN Category "+
                "ON ProductLink.CategoryId = Category.Id "+
                "WHERE InvoiceProduct.Id = @Id", new { Id = id}).FirstOrDefault();
                return output;
            }
        }
        //4. Save To DB
        public static bool SaveInvoiceProduct(InvoiceProductModel invoiceProduct)
        {
            try{
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("INSERT INTO InvoiceProduct "+
                    "(InvoiceId, ProductId, Quantity, Sale, TotalPrice, Weight) "+
                    "VALUES (@InvoiceId, @ProductId, @Quantity, "+
                    "@Sale, @TotalPrice, @Weight);", invoiceProduct);
                }
            } 
            catch(Exception ex){
                General.LogError(ex);
                return false;
            }
            return true;
        }
        //5. Update By Id
        public static bool UpdateInvoiceProductById(InvoiceProductModel invoiceProduct)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var count = cnn.Execute("UPDATE InvoiceProduct "+
                    "SET Quantity= @Quantity, Sale= @Sale, TotalPrice= @TotalPrice, " +
                    "Weight= @Weight "+
                    "WHERE Id= @Id", invoiceProduct);
                return count > 0;
            }
        }
        //6. Delete By Id
        public static bool DeleteInvoiceProductById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var affectedRows = cnn.Execute("DELETE FROM InvoiceProduct "+
                    "WHERE InvoiceProduct.Id = @Id ", new {Id = id});
                return affectedRows > 0;
            }
        }
        //7. Find Invoice Total by Id
        public static InvoiceProductModel GetInvoiceTotalById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<InvoiceProductModel>("SELECT " +
                    "InvoiceProduct.InvoiceId, " +
                    "SUM(InvoiceProduct.TotalPrice) TotalPrice " +
                "FROM InvoiceProduct " +
                "WHERE InvoiceProduct.InvoiceId = @Id", new { Id = id }).FirstOrDefault();
                return output;
            }
        }
    }
}
