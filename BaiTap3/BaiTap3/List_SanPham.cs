using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3
{
    public class List_SanPham
    {
        private static List_SanPham instance;
        public static List_SanPham Instance
        {
            get
            {
                if(instance == null)
                    instance = new List_SanPham();
                return instance;
            }
            set => instance = value;
        }

        List<SanPham> listSanPham;

        public List<SanPham> ListSanPham { get => listSanPham; set => listSanPham = value; }

        public List_SanPham() { 
            listSanPham = new List<SanPham>();
            listSanPham.Add(new SanPham("1", "1", "1", "1", "1", new DateTime(2024, 10, 3)));
        }
        //public List_SanPham(string masp, string tensp, string soluong, string dongia, string xuatxu, DateTime ngay)
        //{
        //    listSanPham.Add(new SanPham(masp,tensp,soluong,dongia,xuatxu, ngay));
        //}
    }
}
