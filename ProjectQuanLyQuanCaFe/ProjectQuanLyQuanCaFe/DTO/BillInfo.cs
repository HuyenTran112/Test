using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ProjectQuanLyQuanCaFe.DTO
{
    public class BillInfo
    {
        private int iD;
        private int foodID;
        private int billID;
        private int count;
        public BillInfo( DataRow rows )
        {
            this.ID = (int)rows["id"];
            this.BillID = (int)rows["idbill"];
            this.FoodID = (int)rows["idfood"];
            this.Count = (int)rows["count"];
        }
        public BillInfo(int id,int foodid,int billid,int count)
        {
            this.ID = id;
            this.BillID = billid;
            this.FoodID = foodid;
            this.Count = count;
        }

        public int ID { get => iD; set => iD = value; }
        public int FoodID { get => foodID; set => foodID = value; }
        public int BillID { get => billID; set => billID = value; }
        public int Count { get => count; set => count = value; }
    }
}
