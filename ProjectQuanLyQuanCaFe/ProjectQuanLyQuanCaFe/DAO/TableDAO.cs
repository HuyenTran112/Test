using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectQuanLyQuanCaFe.DTO;
using System.Data;
namespace ProjectQuanLyQuanCaFe.DAO
{
    public class TableDAO
    {
        public static int TableWidth = 50;
        public static int TableHeight = 50;
        private static TableDAO instance;
        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            set { TableDAO.instance = value;  }
        }
        private TableDAO() { }
        public List <Table> LoadTableList()
        {
            List<Table> TableList = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.TableFood");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                TableList.Add(table);
            }
            return TableList;
        }
    }
}
