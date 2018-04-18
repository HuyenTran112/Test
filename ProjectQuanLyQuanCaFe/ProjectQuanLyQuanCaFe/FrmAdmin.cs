using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ProjectQuanLyQuanCaFe.DAO;
namespace ProjectQuanLyQuanCaFe
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
            //LoadAccountList();
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {

        }
        //void LoadAccountList()
        //{
        //    string connnectionSTR = "Data Source=.\\sqlexpress;Initial Catalog=QuanLyQuanCaFe;Integrated Security=True";
        //    SqlConnection connection = new SqlConnection(connnectionSTR);

        //    string query = "select DisplayName as [Tên hiển thị] from Account";
        //    connection.Open();
        //    SqlCommand command = new SqlCommand(query,connection);

        //    DataTable data = new DataTable();
        //    SqlDataAdapter adapter = new SqlDataAdapter(command);
        //    adapter.Fill(data);
        //    connection.Close();
        //    dtgvAccount.DataSource = data;
        //}
        //void LoadAccountList()
        //{
        //    string query = "select DisplayName as [Tên hiển thị] from Account";
        //    DataProvider provider = new DataProvider();
        //    dtgvAccount.DataSource = provider.ExcecuteQuery(query);
        //}
        //void LoadAccountList()
        //{
        //    string query = "exec USP_GetAccountBayUserName @username=N'K9'";
        //    DataProvider provider = new DataProvider();
        //    dtgvAccount.DataSource = provider.ExcecuteQuery(query);
        //}
        //void LoadAccountList()
        //{
        //    string query = "exec USP_GetAccountBayUserName @username";
            
        //    dtgvAccount.DataSource = DataProvider.Instance.ExcecuteQuery(query,new object[] { "staff" });
        //}

        //void LoadFoodList()
        //{
        //    string query = "select *from food";

        //    dtgvFood.DataSource = DataProvider.Instance.ExcecuteQuery(query);
        //}
    }
}
