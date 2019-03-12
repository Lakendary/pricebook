using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace PriceBookClassLibrary
{
    public class SqliteDAStore
    {
        //******************************************************************************************************
        //  Index
        //******************************************************************************************************
        //  1. Database Connection String
        //  2. Get All
        //  3. Get All By Id
        //  4. Save To Database
        //  5. Update By Id
        //  6. Delete By Id
        //  7. Get All for Combobox 
        //******************************************************************************************************

        //A. Connection String
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        //1. Get All
        public static List<StoreModel> GetAllStores()
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<StoreModel>("SELECT " +
                        "Id, Name, Location " +
                        "FROM Store", new DynamicParameters());
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                General.LogError(ex);
                return null;
            }
        }
        //2. Get By Id
        public static StoreModel GetStoreById(int id)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<StoreModel>("SELECT " +
                        "Id, Name, Location " +
                        "FROM Store " +
                        "WHERE Id = @Id", new { Id = id }).FirstOrDefault();
                    return output;
                }
            }
            catch (Exception ex)
            {
                General.LogError(ex);
                return null;
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
                    return true;
                }
            } 
            catch(Exception ex){
                General.LogError(ex);
                return false;
            }
        }
        //4. Update By Id
        public static bool UpdateStoreById(StoreModel store)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var count = cnn.Execute("UPDATE Store " +
                        "SET Name= @Name, Location= @Location " +
                        "WHERE Id= @Id", store);
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                General.LogError(ex);
                return false;
            }
        }
        //5. Delete By Id
        public static bool DeleteStoreById(int id)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var affectedRows = cnn.Execute("DELETE FROM Store " +
                        "WHERE Id= @Id", new { Id = id });
                    return affectedRows > 0;
                }
            }
            catch (Exception ex)
            {
                General.LogError(ex);
                return false;
            }
        }
        //6. Get All
        public static List<StoreModel> GetAllStoresForComboBox()
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<StoreModel>("SELECT Store.Id, Store.Name||', '||Store.Location AS Name " +
                        "FROM Store; ", new DynamicParameters());
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                General.LogError(ex);
                return null;
            }
        }
    }
}
