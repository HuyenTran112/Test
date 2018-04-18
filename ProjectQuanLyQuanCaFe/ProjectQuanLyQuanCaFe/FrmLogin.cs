using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectQuanLyQuanCaFe.DAO;
namespace ProjectQuanLyQuanCaFe
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string passWord = txtPassWord.Text;
            if (Login(userName, passWord))
            {
                FrmTableManager f = new FrmTableManager();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }
        bool Login(string username,string password)
        {
            return AccountDAO.Instance.Login(username,password);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có muốn thoát khỏi chương trình hay không?",
                "Hỏi thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if(ret==DialogResult.OK)
            {
                Close();
            }
        }
    }
}
