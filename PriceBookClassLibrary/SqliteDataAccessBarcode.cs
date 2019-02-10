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
    public class SqliteDataAccessBarcode
    {
        //A. Connection String
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        //1. Save To DB
        public static bool SaveBarcode(BarcodeModel barcode)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("INSERT INTO Barcode ( "+
                        "Barcode, ProductId) "+
                        "VALUES( @Barcode, @ProductId); ", barcode);
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
