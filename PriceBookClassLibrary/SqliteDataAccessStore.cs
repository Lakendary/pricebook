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
    public class SqliteDAStore
    {
        //A. Connection String
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        //1. Get All
        public static List<StoreModel> GetAllStores()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StoreModel>("SELECT " +
                    "Id, Name, Location " +
                    "FROM Store", new DynamicParameters());
                return output.ToList();
            }
        }
        //2. Get By Id
        public static StoreModel GetStoreById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StoreModel>("SELECT "+
                    "Name, Location "+
                    "FROM Store "+
                    "WHERE Id = @Id", new { Id = id}).FirstOrDefault();
                return output;
            }
        }
        //3. Save To DB
        public static bool SaveStore(StoreModel store)
        {
            try{
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("INSERT INTO Store (Name, Location) "+
                        "VALUES (@Name, @Location)", store);
                }
            } 
            catch(Exception ex){
                General.LogError(ex);
                return false;
            }
            return true;
        }
        //4. Update By Id
        public static bool UpdateStoreById(StoreModel store)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var count = cnn.Execute("UPDATE Store "+
                    "SET Name= @Name, Location= @Location "+
                    "WHERE Id= @Id", store);
                return count > 0;
            }
        }
        //5. Delete By Id
        public static bool DeleteStoreById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var affectedRows = cnn.Execute("DELETE FROM Store "+
                    "WHERE Id= @Id", new {Id = id});
                return affectedRows > 0;
            }
        }
        //6. Get All
        public static List<StoreModel> GetAllStoresForComboBox()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StoreModel>("SELECT Store.Id, Store.Name||', '||Store.Location AS Name "+
                    "FROM Store; ", new DynamicParameters());
                return output.ToList();
            }
        }
    }
}
