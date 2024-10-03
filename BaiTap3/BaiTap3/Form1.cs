using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap3
{
    public partial class Form1 : Form
    {


        List<SanPham> sanPhams;
        public Form1()
        {
            InitializeComponent();

            label7.Text = "Ngày \nhết hạn:";


            sanPhams = new List<SanPham>
            {
                 new SanPham("1","Kim chi","40","30000","Nhật Bản",new DateTime(2024,12,31)),
                 new SanPham("2","Mì cay","20","50000","Nhật Bản",new DateTime(2024,11,30)),
                 new SanPham("3","Trà sữa","10","35000","Việt Nam",new DateTime(2024,9,30)),
            };
            //dsSP.DataSource = sanPhams;

            dsSP.Columns.Add("MaSP", "Mã SP");
            dsSP.Columns.Add("TenSP", "Tên SP");
            dsSP.Columns.Add("SoLuong", "Sô lượng");
            dsSP.Columns.Add("DonGia", "Đơn giá");
            dsSP.Columns.Add("XuatXu", "Xuất xứ");
            dsSP.Columns.Add("NgayHetHan", "Ngày hết hạn");
            
            Update_dsSP();

            ds_TruyVan.Columns.Add("MaSP", "Mã SP");
            ds_TruyVan.Columns.Add("TenSP", "Tên SP");
            ds_TruyVan.Columns.Add("SoLuong", "Sô lượng");
            ds_TruyVan.Columns.Add("DonGia", "Đơn giá");
            ds_TruyVan.Columns.Add("XuatXu", "Xuất xứ");
            ds_TruyVan.Columns.Add("NgayHetHan", "Ngày hết hạn");
        }

        //Vẽ nền gradient
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.LightYellow, Color.LightPink, 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

           
        }

        private void btn_luusp_Click(object sender, EventArgs e)
        {

            string masp = txt_masp.Text;
            string tensp = txt_tensp.Text;
            string soluong = txt_soluong.Text;
            string dongia = txt_dongia.Text;
            string xuatxu = txt_xuatxu.Text;
            DateTime ngayhethan = datetime_hethan.Value;

            if(!string.IsNullOrWhiteSpace(masp)&& !string.IsNullOrWhiteSpace(tensp)&&!string.IsNullOrWhiteSpace(soluong)&& !string.IsNullOrWhiteSpace(dongia) && !string.IsNullOrWhiteSpace(xuatxu))
            {
                SanPham sp = new SanPham(masp, tensp, soluong, dongia, xuatxu, ngayhethan);

                sanPhams.Add(sp);

                Update_dsSP();
                


                txt_masp.Clear();
                txt_tensp.Clear();
                txt_soluong.Clear();
                txt_dongia.Clear();
                txt_xuatxu.Clear();

            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            



            //datetime_hethan = new DateTimePicker();

        }

        private void btn_xoasp_Click(object sender, EventArgs e)
        {
            if (dsSP.SelectedRows.Count > 0)
            {

                foreach (DataGridViewRow row in dsSP.SelectedRows)
                {
                    int index = row.Index;
                    sanPhams.RemoveAt(index);
                    dsSP.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.");
            }
        }

        private void Update_dsSP()
        {
            // Xóa tất cả các hàng trong DataGridView
            dsSP.Rows.Clear();

            // Thêm sản phẩm từ List vào DataGridView
            foreach (var sp in sanPhams)
            {
                dsSP.Rows.Add(sp.MaSP, sp.TenSP, sp.SoLuong, sp.DonGia, sp.XuatXu, sp.NgayHetHan);
            }
        }

        private void btn_dgcaonhat_Click(object sender, EventArgs e)
        {
            var dgcaonhat = sanPhams.OrderByDescending(sp => sp.DonGia).FirstOrDefault();

            ds_TruyVan.Rows.Clear();

            if(dgcaonhat != null)
            {
                ds_TruyVan.Rows.Add(dgcaonhat.MaSP, dgcaonhat.TenSP, dgcaonhat.SoLuong, dgcaonhat.DonGia, dgcaonhat .XuatXu, dgcaonhat.NgayHetHan);
            }
            else
            {
                MessageBox.Show("Không có sản phẩm nào.");
            }
        }

        private void btn_spnhatban_Click(object sender, EventArgs e)
        {
            var spNhatBan = sanPhams.FirstOrDefault(sp => sp.XuatXu.Equals("Nhật Bản", StringComparison.OrdinalIgnoreCase));

            ds_TruyVan.Rows.Clear(); // Xóa dữ liệu hiện tại

            if (spNhatBan != null)
            {
                ds_TruyVan.Rows.Add(spNhatBan.MaSP, spNhatBan.TenSP, spNhatBan.SoLuong, spNhatBan.DonGia, spNhatBan.XuatXu, spNhatBan.NgayHetHan);
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm có xuất xứ từ Nhật Bản.");
            }
        }

        private void btn_xuatspquahan_Click(object sender, EventArgs e)
        {
            var spHetHan = sanPhams.Where(sp => sp.NgayHetHan < DateTime.Now).ToList();

            ds_TruyVan.Rows.Clear();

            if(spHetHan.Any())
            {
                foreach(var sp in spHetHan)
                {
                    ds_TruyVan.Rows.Add(sp.MaSP, sp.TenSP, sp.SoLuong, sp.DonGia, sp.XuatXu, sp.NgayHetHan);
                }    
            }
            else
            {
                MessageBox.Show("Không có sản phẩm nào quá hạn.");
            }
        }

        private void btn_xuatsptheodg_Click(object sender, EventArgs e)
        {
            float dongia_a;
            float dongia_b;
            if (!string.IsNullOrWhiteSpace(txt_dongiaa.Text)&&!string.IsNullOrWhiteSpace(txt_dongiab.Text))
            {
                dongia_a = int.Parse(txt_dongiaa.Text);
                dongia_b = int.Parse(txt_dongiab.Text);

                var DonGiaTuA_B = sanPhams.Where(sp => int.Parse(sp.DonGia) >= dongia_a && int.Parse(sp.DonGia) <= dongia_b).ToList();

                ds_TruyVan.Rows.Clear();

                if (DonGiaTuA_B.Any())
                {
                    foreach (var sp in DonGiaTuA_B)
                    {
                        ds_TruyVan.Rows.Add(sp.MaSP, sp.TenSP, sp.SoLuong, sp.DonGia, sp.XuatXu, sp.NgayHetHan);
                    }

                }
                else
                {
                    MessageBox.Show("Không có sản phẩm nào có đơn giá từ " + txt_dongiaa.Text + " đến " + txt_dongiab.Text + ".");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đơn giá nhỏ nhất và đơn giá lớn nhất!");
            }
            

            
        }

        private void btn_xoasptheoxuatxu_Click(object sender, EventArgs e)
        {
            string xuatxu = txt_xoaxuatxu.Text;

            var xoaSPXuatXu = sanPhams.Where(sp => sp.XuatXu.Equals(xuatxu, StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (var sp in xoaSPXuatXu)
            {
                sanPhams.Remove(sp);
            }

            Update_dsSP();

            MessageBox.Show($"{xoaSPXuatXu.Count} sản phẩm có xuất xứ " + xuatxu + " đã bị xóa.");
        }

        private void btn_kiemtraquahan_Click(object sender, EventArgs e)
        {
            var spHetHan = sanPhams.Where(sp => sp.NgayHetHan < DateTime.Now).ToList();

            if(spHetHan !=null)
            {
                MessageBox.Show($"{spHetHan.Count} sản phẩm hết hạn.");
            }
            else
            {
                MessageBox.Show("Không có sản phẩm nào quá hạn.");
            }
        }

        private void btn_xoatoanbo_Click(object sender, EventArgs e)
        {
            sanPhams.Clear();
            Update_dsSP();
            MessageBox.Show("Đã xóa toàn bộ sản phẩm trong kho!");
        }

        private void btn_xoatoanboquahan_Click(object sender, EventArgs e)
        {
            var spHetHan = sanPhams.Where(sp => sp.NgayHetHan < DateTime.Now).ToList();


            
            foreach (var sp in spHetHan)
            {
                sanPhams.Remove(sp);
            }
            
            Update_dsSP();
            MessageBox.Show("Đã xóa toàn bộ sản phẩm nào quá hạn.");
            
        }
    }
}
