using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace copyprojectshaifalijain
{
    class SqlOperations
    {
    //    public static (bool success, Exception exception, DataSet dataSet) GetReferenceTablesDataSet1()
    //    {

    //        DataSet ds = new DataSet();

    //        try
    //        {
    //            SqlDataAdapter adapter = new SqlDataAdapter();

    //            using (var cn = new SqlConnection(ConnectionString()))
    //            {
    //                SqlCommand command = new SqlCommand(SqlStatements.ReferenceTableStatements1, cn);
    //                adapter.SelectCommand = command;

    //                adapter.Fill(ds);

    //                ds.Tables[0].TableName = "Categories";
    //                ds.Tables[1].TableName = "ContactType";
    //                ds.Tables[2].TableName = "Countries";

    //                return ((true, null, ds));
    //            }

    //        }
    //        catch (Exception localException)
    //        {
    //            return ((false, localException, null));
    //        }
    //    }
    //}

}
}
