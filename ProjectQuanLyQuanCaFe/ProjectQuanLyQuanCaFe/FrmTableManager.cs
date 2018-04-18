using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Globalization;
using ProjectQuanLyQuanCaFe.DTO;
using ProjectQuanLyQuanCaFe.DAO;
namespace ProjectQuanLyQuanCaFe
{
    public partial class FrmTableManager : Form
    {
        public FrmTableManager()
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
        }
        #region Method
        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cboCategory.DataSource = listCategory;
            cboCategory.DisplayMember = "Name";

        }
        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodListByCategoryID(id);
            cboFood.DataSource = listFood;
            cboFood.DisplayMember = "Name";

        }
        void LoadTable()
        {
            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }

                flpTable.Controls.Add(btn);
            }
        }

        #endregion Method
        #region Envent
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAccountProFile frm = new FrmAccountProFile();
            
            frm.ShowDialog();
            
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdmin frm = new FrmAdmin();
            frm.ShowDialog();
        }

        private void FrmTableManager_Load(object sender, EventArgs e)
        {

        }
        #endregion Event
        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }

        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<ProjectQuanLyQuanCaFe.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float TotalPrice = 0;
            foreach (ProjectQuanLyQuanCaFe.DTO.Menu item in listBillInfo)
            {
                
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.ThanhTien.ToString());
                TotalPrice += item.ThanhTien;
                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");//Chú ý nếu bạn chưa có kiểu đó thì add thêm thư viện Globalization
            
            txtTotalPrice.Text = TotalPrice.ToString("c",culture);//Chuyển về kiểu tiền tệ
        }

        private void flpTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb=sender as ComboBox;
            if(cb.SelectedItem==null)
            {
                return;
            }
            Category selected = cb.SelectedItem as Category;
            id = selected.ID;
            LoadFoodListByCategoryID(id);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn");
                return;
            }

            int idBill = BillDAO.Instance.GetUnCheckBillIDByTabbleID(table.ID);
            int foodID = (cboFood.SelectedItem as Food).ID;
            int count = (int)nmCount.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
            }

            ShowBill(table.ID);

            LoadTable();
        }
    }
}
