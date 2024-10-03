using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3
{
    public class SanPham
    {
        private string maSP;

        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string SoLuong { get => soLuong; set => soLuong = value; }
        public string DonGia { get => donGia; set => donGia = value; }
        public string XuatXu { get => xuatXu; set => xuatXu = value; }
        public DateTime NgayHetHan { get => ngayHetHan; set => ngayHetHan = value; }

        private string tenSP;
        private string soLuong;
        private string donGia;
        private string xuatXu;
        private DateTime ngayHetHan;

        public SanPham(string maSP, string tenSP, string soLuong, string donGia, string xuatXu, DateTime ngayHetHan)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.soLuong = soLuong;
            this.donGia = donGia;
            this.xuatXu = xuatXu;
            this.ngayHetHan = ngayHetHan;
        }
    }
}
