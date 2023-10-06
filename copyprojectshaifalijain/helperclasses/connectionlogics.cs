using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace copyprojectshaifalijain.helperclasses
{
    public static class connectionlogics
    {
        public static string connectionstring = ConfigurationManager.ConnectionStrings["connectionstringname"].ConnectionString;
        public static SqlConnection connection;
        public static SqlCommand command;

        static void openconnection()
        {
            connection = new SqlConnection();
            connection.ConnectionString = connectionstring;
            connection.Open();
        }

        static void closeconnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public static SqlDataReader selectquery(string query)
        {
            openconnection();
            command = new SqlCommand(query, connection);
            return command.ExecuteReader();

        }

        public static int nonquery(string query)
        {
            openconnection();
            command = new SqlCommand(query, connection);
            int resultcode = command.ExecuteNonQuery();
            closeconnection();
            return resultcode;
        }

        // this method was declared something else by coder baba
        public static DataSet FillDataGridView(string query)
        {
            openconnection();
            command = new SqlCommand(query, connection);
            SqlDataAdapter dataadapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            dataadapter.Fill(ds);
            return ds;
        }

    }
}
