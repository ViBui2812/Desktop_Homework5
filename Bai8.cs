using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Homework5
{
    public partial class Bai8 : Form
    {
        public Bai8()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;
        int vt = -1;
        void LoadLoaiSanPham ()
        {
                ds = new DataSet();
                da = new SqlDataAdapter("Select * From LoaiSanPham", conn);
                da.Fill(ds, "LoaiSanPham");
                cboLoaiSP.DataSource = ds.Tables[0];
                cboLoaiSP.DisplayMember = "TenLoai";
                cboLoaiSP.ValueMember = "MaLoai";
        }
            
        
        
        private void Bai8_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection("Data Source=VIS-LAPTOP;Initial Catalog=QLBH;Integrated Security=True");
                conn.Open();
                ds = new DataSet();
                da = new SqlDataAdapter("Select * From SanPham", conn);
                da.Fill(ds, "SanPham");
                dt = ds.Tables["SanPham"];
                btnFirst.PerformClick();
                LoadLoaiSanPham();

            }
            catch (SqlException)
            {
                MessageBox.Show("Chưa nhận được dữ liệu");
            }
        }

        private void cboLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0) return;
            vt = 0;
            txtMaSP.Text = dt.Rows[vt]["MaSP"].ToString();
            txtTenSP.Text = dt.Rows[vt]["TenSP"].ToString();
            txtDvt.Text = dt.Rows[vt]["DVTinh"].ToString();
            txtDongia.Text = dt.Rows[vt]["DonGia"].ToString();
            cboLoaiSP.SelectedValue = dt.Rows[vt]["MaLoai"].ToString();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0) return;
            vt = dt.Rows.Count - 1;
            txtMaSP.Text = dt.Rows[vt]["MaSP"].ToString();
            txtTenSP.Text = dt.Rows[vt]["TenSP"].ToString();
            txtDvt.Text = dt.Rows[vt]["DVTinh"].ToString();
            txtDongia.Text = dt.Rows[vt]["DonGia"].ToString();
            cboLoaiSP.SelectedValue = dt.Rows[vt]["MaLoai"].ToString();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0) return;
            vt++;
            if (vt > dt.Rows.Count - 1) vt = dt.Rows.Count - 1;
            txtMaSP.Text = dt.Rows[vt]["MaSP"].ToString();
            txtTenSP.Text = dt.Rows[vt]["TenSP"].ToString();
            txtDvt.Text = dt.Rows[vt]["DVTinh"].ToString();
            txtDongia.Text = dt.Rows[vt]["DonGia"].ToString();
            cboLoaiSP.SelectedValue = dt.Rows[vt]["MaLoai"].ToString();

        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0) return;
            vt--;
            if (vt < 0) vt = 0;
            txtMaSP.Text = dt.Rows[vt]["MaSP"].ToString();
            txtTenSP.Text = dt.Rows[vt]["TenSP"].ToString();
            txtDvt.Text = dt.Rows[vt]["DVTinh"].ToString();
            txtDongia.Text = dt.Rows[vt]["DonGia"].ToString();
            cboLoaiSP.SelectedValue = dt.Rows[vt]["MaLoai"].ToString();

        }
    }
}
