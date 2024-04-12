using System.Data;
using System.Reflection;

namespace CompareDatabase.WindowUI
{
    public class TextHelper
    {
        public static Dictionary<string, string> TableToText(DataTable table)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            
            if (table != null && table.Rows != null && table.Rows.Count > 0)
            {
                var columns = table.Columns.Cast<DataColumn>().ToList();

                foreach (DataRow Row in table.Rows)
                {
                    foreach(DataColumn column in columns)
                    {
                        if (!column.ColumnName.Equals("Id", StringComparison.OrdinalIgnoreCase) &&
                            !column.ColumnName.Equals("clientid", StringComparison.OrdinalIgnoreCase))
                        {
                            if (result.ContainsKey(column.ColumnName))
                            {

                            }
                            else
                            {
                                result.Add(column.ColumnName, $"{Row[column.ColumnName]}");
                            }
                        }
                    }
                }
            }
            return result;
        }

        public static Dictionary<string, string> TableToText<T>(T client) where T : class
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            if (client != null)
            {
                var properties = GetProperties<T>();

                foreach (var property in properties)
                {
                    result.Add(property.Name, $"{property.GetValue(client)}");
                }
            }
            return result;
        }

        public static PropertyInfo[] GetProperties<T>()
        {
            Type type = typeof(T);
            return type.GetProperties();
        }
    }
}
