using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace PriceBookClassLibrary
{
    public class SqliteDataAccessGeneral
    {
        //A. Connection String
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        //1. Seed Database with some sample data
        public static bool SeedDatabase()
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    string sql = File.ReadAllText(@".\SeedDB.txt");
                    cnn.Execute(sql);
                }
            }
            catch (Exception ex)
            {
                General.LogError(ex);
                return false;
            }
            return true;
        }
    }
}
