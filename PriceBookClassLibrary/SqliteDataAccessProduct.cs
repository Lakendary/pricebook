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
                    "ProductLink.UoM UoM, " +
                    "ProductLink.Weighted, " +
                    "Product.Deleted " +
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
                    "Category.Name CategoryName, " +
                    "ProductLink.UoM, " +
                    "ProductLink.Weighted, "+
                    "Product.Deleted " +
                "FROM Product " +
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
                var affectedRows = cnn.Execute("UPDATE Product " +
                    "SET Deleted='Deleted' "+
                    "WHERE Product.Id= @Id", new {Id = id});
                return affectedRows > 0;
            }
        }
        //7. Get All By Search Criteria
        public static List<ProductModel> GetAllProducts(ProductModel product)
        {
            string sql = BuildProductSearchSqlString(product);
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProductModel>(sql, new DynamicParameters());
                return output.ToList();
            }
        }
        //8. Build a search string for Get All by Search Criteria
        private static string BuildProductSearchSqlString(ProductModel product)
        {
            //Default string
            string output = "SELECT " +
                    "Product.Id, " +
                    "Product.BrandName, " +
                    "Product.Description, " +
                    "Product.PackSize, " +
                    "ProductLink.Name ProductLinkName, " +
                    "Category.Name CategoryName, " +
                    "Product.ProductLinkId ProductLinkId, " +
                    "ProductLink.UoM UoM, " +
                    "ProductLink.Weighted " +
                "FROM Product " +
                "LEFT JOIN ProductLink " +
                "ON Product.ProductLinkId = ProductLink.Id " +
                "LEFT JOIN Category " +
                "ON ProductLink.CategoryId = Category.Id " +
                "WHERE 1=1 ";
            //Add search criteria to search string depending if product's properties are not empty
            if (product.BrandName != "")
                output += string.Format("AND Product.BrandName LIKE '%{0}%' ", product.BrandName);
            if (product.Description != "")
                output += string.Format("AND Product.Description LIKE '%{0}%' ", product.Description);
            if (product.ProductLinkName != "")
                output += string.Format("AND ProductLink.Name LIKE '%{0}%' ", product.ProductLinkName);
            if (product.CategoryName != "<ALL>")
                output += string.Format("AND Category.Name LIKE '%{0}%' ", product.CategoryName);
            if (product.Weighted != "<ALL>")
                output += string.Format("AND ProductLink.Weighted LIKE '%{0}%' ", product.Weighted);

            return output;
        }
        //9. Save To DB
        public static int SaveProductAndGetId(ProductModel product)
        {
            int id = 0;
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    id = cnn.Query<int>("INSERT INTO Product " +
                    "(Description, BrandName, PackSize, ProductLinkId) " +
                    "VALUES (@Description, @BrandName, @PackSize, @ProductLinkId);" +
                    "SELECT last_insert_rowid();", product).Single();
                }
            }
            catch (Exception ex)
            {
                General.LogError(ex);
                return id = 0;
            }
            return id;
        }
    }
}
