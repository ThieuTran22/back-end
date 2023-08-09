using System.Data;
using System.Data.SqlClient;

namespace back_end
{
    public class cDatabase
    {
        private static string strConn = @"Data Source=THIEU\SQLEXPRESS;Initial Catalog=QuizzSystemFinal;Integrated Security=True";
        private static SqlConnection conn = new SqlConnection(strConn);
        public static void OpenConnect()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }
        public static void CloseConnect()
        {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
        }
        public static DataTable GetTable(string querySelect)
        {
            OpenConnect();
            DataTable tb = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(querySelect, strConn);
            adap.Fill(tb);
            CloseConnect();
            return tb;
        }
        public static string GetOneValue(string querySelect)
        {
            OpenConnect();
            DataTable tb = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(querySelect, strConn);
            adap.Fill(tb);
            CloseConnect();
            return (string)tb.Rows[0][0];
        }
        public static void ExecuteCMD(string QueryCMD)
        {
            OpenConnect();
            SqlCommand cmd = new SqlCommand(QueryCMD, conn);
            cmd.ExecuteNonQuery();
            CloseConnect();
        }
    }
}
