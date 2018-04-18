using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectQuanLyQuanCaFe.DTO;
namespace ProjectQuanLyQuanCaFe.DAO
{
    public class BillInfoDAO
    {
       
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }

        private BillInfoDAO() { }
        public List <BillInfo> GetListBillInfo (int id)
        {
            List<BillInfo> ListBillInfo = new List<BillInfo>();
            string query = "select * from dbo.billinfo where idbill=" + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                ListBillInfo.Add(info);
            }
            return ListBillInfo;
        }
        public void InsertBillInfo(int idbill,int idfood,int count)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_InsertBillInfo @idbill, @idfood ,@count", new object[] { idbill,idfood,count });
        }
    }
}
