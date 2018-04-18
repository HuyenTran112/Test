using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectQuanLyQuanCaFe.DTO;
namespace ProjectQuanLyQuanCaFe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get { if(BillDAO.instance==null) BillDAO.instance=new BillDAO();return BillDAO.instance; }
            set { BillDAO.instance = value; }
        }
        private BillDAO()
        {

        }
        public int GetUnCheckBillIDByTabbleID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.bill WHERE idtable = " + id + " AND status = 0");

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }

            return -1;
        }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_InsertBill @idtable",new object[] { id });
        }
        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("select max(id) from bill");
            }
            catch
            {
                return 1;
            }
        }
     }
}
