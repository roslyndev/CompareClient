using Microsoft.Data.SqlClient;
using System.Data;

namespace CompareDatabase.WindowUI
{
    public static class ExtendSqlCommand
    {
        public static DataTable ExecuteTable(this SqlCommand cmd)
        {
            var result = new DataTable();
            using (var adp = new SqlDataAdapter(cmd))
            {
                adp.Fill(result);
            }
            return result;
        }

        public static T ExecuteEntity<T>(this SqlCommand cmd) where T : new()
        {
            var result = new T();
            var dt = cmd.ExecuteTable();
            if (dt != null && dt.Rows.Count > 0)
            {
                result = EntityHelper.ColumnToEntity<T>(dt);
            }
            return result;
        }

        public static List<T> ExecuteEntities<T>(this SqlCommand cmd) where T : new()
        {
            var result = new List<T>();
            var dt = cmd.ExecuteTable();
            if (dt != null && dt.Rows.Count > 0)
            {
                result = EntityHelper.ColumnToEntities<T>(dt);
            }
            return result;
        }


        public static int ExecuteCount(this SqlCommand cmd)
        {
            int result = 0;

            try
            {
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch
            {
                result = 0;
            }

            return result;
        }

        public static void Set(this SqlParameterCollection Parameter, string Name, SqlDbType type, object? Value)
        {
            Parameter.Add(Name, type);
            Parameter[Name].Value = Value;
        }

        public static void Set(this SqlParameterCollection Parameter, string Name, SqlDbType type, object? Value, int size)
        {
            Parameter.Add(Name, type, size);
            Parameter[Name].Value = Value;
        }

        public static void Set(this SqlParameterCollection Parameter, string Name, decimal Value, byte Scale)
        {
            Parameter.Add(Name, SqlDbType.Decimal, 18);
            Parameter[Name].Precision = 18;
            Parameter[Name].Scale = Scale;
            Parameter[Name].Value = Value;
        }

        public static void SetOutput(this SqlParameterCollection Parameter, string Name, SqlDbType type)
        {
            Parameter.Add(Name, type);
            Parameter[Name].Direction = ParameterDirection.Output;
        }

        public static void SetOutput(this SqlParameterCollection Parameter, string Name, SqlDbType type, int size)
        {
            Parameter.Add(Name, type, size);
            Parameter[Name].Direction = ParameterDirection.Output;
        }

        public static void SetReturnValue(this SqlParameterCollection Parameter)
        {
            Parameter.Add("@Code", SqlDbType.BigInt);
            Parameter["@Code"].Direction = ParameterDirection.Output;
            Parameter.Add("@Value", SqlDbType.VarChar, 100);
            Parameter["@Value"].Direction = ParameterDirection.Output;
            Parameter.Add("@Msg", SqlDbType.NVarChar, 100);
            Parameter["@Msg"].Direction = ParameterDirection.Output;
        }

        public static object GetOutParameterValue(this SqlCommand cmd, string Name)
        {
            return cmd.Parameters[Name].Value;
        }


    }
}
