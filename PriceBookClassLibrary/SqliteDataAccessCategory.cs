using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceBookClassLibrary
{
    public class SqliteDACategory
    {
        //A. Connection String
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        //1. Get All
        public static List<CategoryModel> GetAllCategories()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<CategoryModel>("SELECT " +
                    "Id, MainCategory, Name " +
                    "FROM Category", new DynamicParameters());
                return output.ToList();
            }
        }
        //2. Get By Id
        public static CategoryModel GetCategoryById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<CategoryModel>("SELECT "+
                    "MainCategory, Name "+
                    "FROM Category "+
                    "WHERE Id = @Id", new { Id = id}).FirstOrDefault();
                return output;
            }
        }
        //3. Save To DB
        public static bool SaveCategory(CategoryModel category)
        {
            try{
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("INSERT INTO Category (MainCategory, Name) "+
                        "VALUES (@MainCategory, @Name)", category);
                }
            } 
            catch(Exception ex){
                General.LogError(ex);
                return false;
            }
            return true;
        }
        //4. Update By Id
        public static bool UpdateCategoryById(CategoryModel category)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var count = cnn.Execute("UPDATE Category "+
                    "SET MainCategory= @MainCategory, Name= @Name"+
                    "WHERE Id= @Id", category);
                return count > 0;
            }
        }
        //5. Delete By Id
        public static bool DeleteCategoryById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var affectedRows = cnn.Execute("DELETE FROM Category "+
                    "WHERE Id= @Id", new {Id = id});
                return affectedRows > 0;
            }
        }
        //6. Get Main Category Only
        public static List<CategoryModel> GetMainCategoryOnly()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<CategoryModel>("SELECT " +
                    "Id, Name " +
                    "FROM Category " +
                    "WHERE Category.MainCategory = '';", new DynamicParameters());
                return output.ToList();
            }
        }
        //7. Get Subcategory Only
        public static List<CategoryModel> GetSubcategoryOnly()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<CategoryModel>("SELECT " +
                    "Id, Name " +
                    "FROM Category " +
                    "WHERE Category.MainCategory != '';", new DynamicParameters());
                return output.ToList();
            }
        }
    }
}
