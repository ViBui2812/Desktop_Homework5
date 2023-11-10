using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Homework5
{
    public partial class Bai9 : Form
    {
        //Chuỗi kết nối
        string strConnectionString = "Data Source=VIS-LAPTOP;Initial Catalog=QLBH;Integrated Security=True";
        // Đối tượng kết nối dữ liệu
        SqlConnection conn = null;
        // Đối tượng thực hiện vận chuyển dữ liệu  
        SqlDataAdapter da = null;
        // Đối tượng chứa dữ liệu trong bộ nhớ
        DataSet ds = null;
        //Đối tượng tự động cập nhật dữ liệu
        SqlCommandBuilder cmd = null;


        public Bai9()
        {
            InitializeComponent();
        }

        private void Bai9_Load(object sender, EventArgs e)
        {
            try
            {

                //Khởi động kết nối
                conn = new SqlConnection(strConnectionString);
                //Mở kết nối
                conn.Open();
                // Vận chuyển dữ liệu
                da = new SqlDataAdapter("SELECT * FROM SanPham", conn);
                //Khởi tạo đối tượng chứa dữ liệu
                ds = new DataSet();
                //Đổ dữ liệu vào DataSet
                da.Fill(ds);
                // Đưa dữ liệu lên DataGridView
                dgSanPham.DataSource = ds.Tables[0];

                dgSanPham.Columns[0].HeaderText = "Mã sản phẩm";
                dgSanPham.Columns[1].HeaderText = "Tên sản phẩm";
                dgSanPham.Columns[2].HeaderText = "Đơn vị tính";
                dgSanPham.Columns[3].HeaderText = "Đơn giá";
                dgSanPham.Columns[4].HeaderText = "Mã loại sản phẩm";

            }
            
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!");
            }
            txtMaSP.Enabled = false;
            LoadLoaiSanPham();
            LoadLoaiSanPham();
        }
        void LoadSanPham()
        {
            // Vận chuyển dữ liệu vào ComboBox
            da = new SqlDataAdapter("SELECT * FROM SanPham", conn);
            ds = new DataSet();
            da.Fill(ds, "SanPham");
            dgSanPham.DataSource = ds.Tables["SanPham"];

        }

        void LoadLoaiSanPham()
        {
            // Vận chuyển dữ liệu vào ComboBox
            da = new SqlDataAdapter("SELECT * FROM LoaiSanPham", conn);
            ds = new DataSet();
            da.Fill(ds, "LoaiSanPham");
            cboLoaiSP.DataSource = ds.Tables["LoaiSanPham"];
            cboLoaiSP.DisplayMember = "TenLoai";
            cboLoaiSP.ValueMember = "MaLoai";

        }
        void TimKiem(string keyword)
        {
            try
            {
                //Khởi tạo kết nối
                conn = new SqlConnection(strConnectionString);
                //Mở kết nối
                conn.Open();

                //Khai báo câu truy vấn
                string sql = "";
                if (keyword != "")
                {
                    sql = "SELECT * FROM SanPham Where TenSP like N'%" + keyword + "%'";
                }
                else
                {
                    sql = "SELECT * FROM SanPham";
                }

                // Vận chuyển dữ liệu vào DataGridView dgSanPham
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "ABC");
                dgSanPham.DataSource = ds.Tables["ABC"];

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //Hoàn thành combobox này như 1 filter cho DataGridView
        {
            
        }

        private void Bai9_FormClosing(object sender, FormClosingEventArgs e)
        {
            ds.Dispose();
            ds = null; 
            conn.Close();
            conn = null;
        }

        private void cboLoaiSP_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMaSP.Enabled = true;
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtDvt.Text = "";
            txtDongia.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommandBuilder(da);
            DataRow row = ds.Tables["SanPham"].NewRow();
            row["MaSP"] = txtMaSP.Text;
            row["TenSP"] = txtTenSP.Text;
            row["DVTinh"] = txtDvt.Text;
            row["DonGia"] = txtDongia.Text;
            row["MaLoai"] = cboLoaiSP.SelectedValue.ToString();
            ds.Tables["SanPham"].Rows.Add(row);
            if (da.Update(ds, "SanPham") > 0)
            {
                MessageBox.Show("Luu thanh cong!");
            }
            else
            {
                MessageBox.Show("Luu khong thanh cong!");
            }
            LoadSanPham();

        }
    }
}
