using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ProjectQuanLyQuanCaFe.DTO
{
    public class Menu
    {
        private string foodName;
        private int count;
        private float  price;
        private float thanhTien;

        public string FoodName { get => foodName; set => foodName = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public float ThanhTien { get => thanhTien; set => thanhTien = value; }
        public Menu (string foodname, int count, float price,float thanhtien=0)
        {
            this.FoodName = foodname;
            this.Count = count;
            this.Price = price;
            this.ThanhTien = thanhTien;
        }
        public Menu(DataRow row)
        {
            
            this.FoodName = row["name"].ToString();
            this.Count = (int)row["count"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.ThanhTien = (float)Convert.ToDouble(row["ToTalPrice"].ToString());
            
;        }
    }
}
