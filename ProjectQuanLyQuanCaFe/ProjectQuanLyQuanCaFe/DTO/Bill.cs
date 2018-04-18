using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ProjectQuanLyQuanCaFe.DTO
{
    public class Bill
    {
        private int iD;
        private DateTime? dateCheckin;
        private DateTime? dateCheckout;
        private int status;

        
        public Bill(int id, DateTime? dateCheckin, DateTime? dateCheckout, int status)
        {
            this.ID = id;
            this.DateCheckin = dateCheckin;
            this.DateCheckout = dateCheckout;
            this.Status = status;
        }
        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.DateCheckin = (DateTime)row["dateCheckin"];
            var dateCheckoutTeep = row["dateCheckout"];
            if(dateCheckoutTeep.ToString()!="")
                this.DateCheckout = (DateTime?) dateCheckoutTeep;
            this.Status = (int)row["Status"];
        }

        public int ID { get => ID1; set => ID1 = value; }
        public int ID1 { get => iD; set => iD = value; }
        public DateTime? DateCheckin { get => dateCheckin; set => dateCheckin = value; }
        public DateTime? DateCheckout { get => dateCheckout; set => dateCheckout = value; }
        public int Status { get => status; set => status = value; }
    }
}
