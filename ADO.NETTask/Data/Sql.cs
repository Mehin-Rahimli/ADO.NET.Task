using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NETTask.Data
{
    internal sealed class Sql
    {
        private const string ConnectionString = "server=DESKTOP-M68M69T\\SQLEXPRESS;database=ADONETTask;trusted_connection=true;integrated security=true;";
        private static SqlConnection conn = new SqlConnection(ConnectionString);

        public int ExecuteCommand(string command)
        {
            int result = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(command, conn);
                result = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();

            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(table);
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                conn.Close();
            }
            return table;   

        }
    }
}
