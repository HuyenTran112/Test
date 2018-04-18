using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace ProjectQuanLyQuanCaFe.DAO
{
    //public class DataProvider

    //{
      // private static DataProvider instance;//Đóng gói Ctrl+R+E
      //public static DataProvider Instance
      //{
      //      get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
      //      set { DataProvider.instance = value; }
      // }
      // private DataProvider();
      //  private string connnectionSTR = "Data Source=.\\sqlexpress;Initial Catalog=QuanLyQuanCaFe;Integrated Security=True";
      // // public DataTable ExcecuteQuery(string query, object[] parameter = null)
      //    {
      //        DataTable data = new DataTable();
      //        using (SqlConnection connection = new SqlConnection(connnectionSTR))
      //        {
      //            connection.Open();
      //            SqlCommand command = new SqlCommand(query, connection);
      //            if(parameter!=null)
      //            {
      //                string[] listPara = query.Split(' ');
      //                int i = 0;
      //                foreach (string item in listPara)
      //                {
      //                    if(item.Contains('@'))
      //                    {
      //                        command.Parameters.AddWithValue(item, parameter[i]);
      //                        i++;
      //                    }
      //                }
      //            }
      //            //command.Parameters.AddWithValue("@username", id);
      //            SqlDataAdapter adapter = new SqlDataAdapter(command);
      //            adapter.Fill(data);
      //            connection.Close();
      //        }
      //        return data;
      //    }


        //public int ExcecuteNonQuery(string query, object[] parameter=null)
        //    {
        //        int data = 0;
        //        using (SqlConnection connection = new SqlConnection(connnectionSTR))
        //        {
        //            connection.Open();
        //            SqlCommand command = new SqlCommand(query, connection);
        //            if (parameter != null)
        //            {
        //                string[] listPara = query.Split(' ');
        //                int i = 0;
        //                foreach (string item in listPara)
        //                {
        //                    if (item.Contains('@'))
        //                    {
        //                        command.Parameters.AddWithValue(item, parameter[i]);
        //                        i++;
        //                    }
        //                }
        //            }
        //            //command.Parameters.AddWithValue("@username", id);
        //            data = command.ExecuteNonQuery();
        //            connection.Close();
        //        }
        //        return data;
        //    }


        //    public object ExcecuteScalar(string query, object[] parameter)
        //    {
        //        object data = 0;
        //        using (SqlConnection connection = new SqlConnection(connnectionSTR))
        //        {
        //            connection.Open();
        //            SqlCommand command = new SqlCommand(query, connection);
        //            if (parameter != null)
        //            {
        //                string[] listPara = query.Split(' ');
        //                int i = 0;
        //                foreach (string item in listPara)
        //                {
        //                    if (item.Contains('@'))
        //                    {
        //                        command.Parameters.AddWithValue(item, parameter[i]);
        //                        i++;
        //                    }
        //                }
        //            }
        //            data = command.ExecuteScalar();
        //            connection.Close();
        //        }
        //        return data;
        //    }
    
        public class DataProvider
        {
            private static DataProvider instance; // Ctrl + R + E

            public static DataProvider Instance
            {
                get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
                private set { DataProvider.instance = value; }
            }

            private DataProvider() { }

            private string connectionSTR = "Data Source=.\\sqlexpress;Initial Catalog=QuanLyQuanCaFe;Integrated Security=True";

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }
    }
}
