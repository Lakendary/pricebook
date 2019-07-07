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
    public class SqliteDAProductLink
    {
        //A. Connection String
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        //1. Get All
        public static List<ProductLinkModel> GetAllProductLinks()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProductLinkModel>("SELECT "+
                    "ProductLink.Id, "+
                    "ProductLink.Name, "+
                    "ProductLink.UoM, "+
                    "ProductLink.MeasurementRate, "+
                    "ProductLink.Weighted, "+
                    "Category.Name CategoryName, " +
                    "Category.Id CategoryId, " +
                    "ProductLink.Deleted "+
                "FROM ProductLink "+
                "LEFT JOIN Category "+
                "ON ProductLink.CategoryId = Category.Id", new DynamicParameters());
                return output.ToList();
            }
        }
        //2. Get By Id
        public static ProductLinkModel GetProductLinkById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProductLinkModel>("SELECT "+
                    "ProductLink.Id, "+
                    "ProductLink.Name, "+
                    "ProductLink.UoM, "+
                    "ProductLink.MeasurementRate, "+
                    "ProductLink.Weighted, "+
                    "Category.Name CategoryName, "+
                    "ProductLink.Deleted " +
                "FROM ProductLink " +
                "LEFT JOIN Category "+
                "ON ProductLink.CategoryId = Category.Id "+
                "WHERE ProductLink.Id = @Id", new { Id = id}).FirstOrDefault();
                return output;
            }
        }
        //3. Save To DB
        public static bool SaveProductLink(ProductLinkModel productLink)
        {
            try{
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("INSERT INTO ProductLink "+
                        "(Name, UoM, Weighted, MeasurementRate, CategoryId) "+
                        "VALUES (@Name, @UoM, @Weighted, @MeasurementRate, @CategoryId);", productLink);
                }
            } 
            catch(Exception ex){
                General.LogError(ex);
                return false;
            }
            return true;
        }
        //4. Update By Id
        public static bool UpdateProductLinkById(ProductLinkModel productLink)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var count = cnn.Execute("UPDATE ProductLink "+
                    "SET Name=@Name, UoM=@UoM, Weighted=@Weighted, "+
                    "MeasurementRate=@MeasurementRate, CategoryId=@CategoryId "+
                    "WHERE Id= @Id", productLink);
                return count > 0;
            }
        }
        //5. Delete By Id
        public static bool DeleteProductLinkById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var affectedRows = cnn.Execute("UPDATE ProductLink " +
                    "SET Deleted='Deleted' "+
                    "WHERE Id= @Id", new {Id = id});
                return affectedRows > 0;
            }
        }
        //6. Get All By Search Criteria
        public static List<ProductLinkModel> GetAllProductLinks(ProductLinkModel productLink)
        {
            string sql = BuildProductLinkSearchSqlString(productLink);
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProductLinkModel>(sql, new DynamicParameters());
                return output.ToList();
            }
        }
        //7. Build a search string for Get All by Search Criteria
        private static string BuildProductLinkSearchSqlString(ProductLinkModel productLink)
        {
            //Default string
            string output = "SELECT " +
                    "ProductLink.Name, " +
                    "ProductLink.UoM, " +
                    "ProductLink.Weighted, " +
                    "ProductLink.MeasurementRate, " +
                    "ProductLink.CategoryId ProductLinkName, " +
                    "Category.Name CategoryName " +
                "FROM ProductLink " +
                "LEFT JOIN Category " +
                "ON ProductLink.CategoryId = Category.Id " +
                "WHERE 1=1 " +
                "AND ProductLink.Deleted LIKE 'Active' ";
            //Add search criteria to search string depending if product's properties are not empty
            if (productLink.Name != "")
                output += string.Format("AND ProductLink.Name LIKE '%{0}%' ", productLink.Name);
            if (productLink.UoM != "")
                output += string.Format("AND ProductLink.UoM LIKE '%{0}%' ", productLink.UoM);
            if (productLink.Weighted != "<ALL>")
                output += string.Format("AND ProductLink.Weighted LIKE '%{0}%' ", productLink.Weighted);
            if (productLink.MeasurementRate > 0)
                output += string.Format("AND ProductLink.Name = {0} ", productLink.MeasurementRate);
            if (productLink.CategoryName != "<ALL>")
                output += string.Format("AND Category.Name LIKE '%{0}%' ", productLink.CategoryName);

            return output;
        }
    }
}
