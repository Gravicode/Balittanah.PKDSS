using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using PKDSS.CoreLibrary.Model;
using System.Data;
using System.Linq;
using System.Data.SQLite;
using Dapper;

namespace PKDSS.MonoApp.Helper
{
    public class SqliteDataAccess
    {
        private static string LoadConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["SqliteCon"].ConnectionString;
        }
        public static List<UnsurModel> LoadUnsur()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UnsurModel>("select * from UnsurTbl", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<UnsurModel> FilterBydateUnsur(DateTime from, DateTime until)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string sql = "select * from UnsurTbl where CreatedDate between @datefrom and @dateuntil";

                DynamicParameters param = new DynamicParameters();
                param.Add("@datefrom", from.AddDays(-1));
                param.Add("dateuntil", until);

                var output = cnn.Query<UnsurModel>(sql, param);
                return output.ToList();
            }
        }

        public static void SaveUnsur(UnsurModel unsur)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into UnsurTbl (Bray1_P2O5, Ca, CLAY, C_N, HCl25_K2O, HCl25_P2O5, Jumlah, K, KB_adjusted, KJELDAHL_N," +
                    "KTK, Mg, Morgan_K2O, Na, Olsen_P2O5, PH_H2O, PH_KCL, RetensiP, SAND, SILT, WBC, CreatedDate) values (@Bray1_P2O5, @Ca," +
                    "@CLAY, @C_N, @HCl25_K2O, @HCl25_P2O5, @Jumlah, @K, @KB_adjusted, @KJELDAHL_N, @KTK, @Mg, @Morgan_K2O, @Na, @Olsen_P2O5," +
                    "@PH_H2O, @PH_KCL, @RetensiP, @SAND, @SILT, @WBC, @CreatedDate) ", unsur);
            }
        }

        public static void DeleteAllUnsur()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("Delete from UnsurTbl", new DynamicParameters());
            }
        }
    }
}
