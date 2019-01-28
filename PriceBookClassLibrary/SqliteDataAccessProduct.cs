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
    public class SqliteDAProduct
    {
        //A. Connection String
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        //1. Get All
        public static List<ProductModel> GetAllProducts()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProductModel>("SELECT "+
                    "Product.Id, "+
                    "Product.BrandName, "+
                    "Product.Description, "+
                    "Product.PackSize, "+
                    "ProductLink.Name ProductLinkName, "+
                    "Category.Name CategoryName, "+
                    "Product.ProductLinkId ProductLinkId, " +
                    "ProductLink.UoM UoM "+
                "FROM Product " +
                "LEFT JOIN ProductLink "+
                "ON Product.ProductLinkId = ProductLink.Id "+
                "LEFT JOIN Category "+
                "ON ProductLink.CategoryId = Category.Id; ", new DynamicParameters());
                return output.ToList();
            }
        }
        //2. Get By Id
        public static ProductModel GetProductById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProductModel>("SELECT "+
                    "Product.Id, "+
                    "Product.BrandName, "+
                    "Product.Description, "+
                    "Product.PackSize, "+
                    "ProductLink.Name ProductLinkName, "+
                    "Category.Name CategoryName "+ 
                "FROM Product "+
                "LEFT JOIN ProductLink "+
                "ON Product.ProductLinkId = ProductLink.Id "+
                "LEFT JOIN Category "+
                "ON ProductLink.CategoryId = Category.Id "+
                "WHERE Product.Id = @Id", new { Id = id}).FirstOrDefault();
                return output;
            }
        }

        //3. Get By Barcode
        public static ProductModel GetProductByBarcode(string barcode)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProductModel>("SELECT "+
                    "Product.Id, "+
                    "Product.BrandName, "+
                    "Product.Description, "+
                    "Product.PackSize, "+
                    "ProductLink.Name ProductLinkName, "+
                    "Category.Name CategoryName "+ 
                "FROM Product "+
                "LEFT JOIN ProductLink "+
                "ON Product.ProductLinkId = ProductLink.Id "+
                "LEFT JOIN Category "+
                "ON ProductLink.CategoryId = Category.Id "+
                "LEFT JOIN Barcode "+
                "ON Barcode.ProductId = Product.Id "+
                "WHERE Barcode.Barcode = @Barcode", new { Barcode = barcode}).FirstOrDefault();
                return output;
            }
        }
        //4. Save To DB
        public static bool SaveProduct(ProductModel product)
        {
            try{
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("INSERT INTO Product "+
                    "(Description, BrandName, PackSize, ProductLinkId) "+
                    "VALUES (@Description, @BrandName, @PackSize, @ProductLinkId);", product);
                }
            } 
            catch(Exception ex){
                General.LogError(ex);
                return false;
            }
            return true;
        }
        //5. Update By Id
        public static bool UpdateProductById(ProductModel product)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var count = cnn.Execute("UPDATE Product "+
                    "SET Description=@Description, BrandName=@BrandName, PackSize=@PackSize, "+
                    "ProductLinkId=@ProductLinkId"+
                    "WHERE Product.Id= @Id", product);
                return count > 0;
            }
        }
        //6. Delete By Id
        public static bool DeleteProductById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var affectedRows = cnn.Execute("DELETE FROM Product "+
                    "WHERE Product.Id= @Id", new {Id = id});
                return affectedRows > 0;
            }
        }
    }
}
