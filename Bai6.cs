using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Desktop_Homework5
{
    public partial class Bai6 : Form
    {
        public Bai6()
        {
            InitializeComponent();
        }
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        void LoadSanPham (string maloai)
        {
            try
            {
                da = null;
                ds = new DataSet();
                da = new SqlDataAdapter("SELECT * FROM SanPham Where Maloai = '" + maloai + "'", conn);
                dataGridView1.DataSource = ds.Tables["SanPham"];
            }
            catch (SqlException)
            {
                MessageBox.Show("Chưa nhận được dữ liệu");
            }
        }
        private void Bai6_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection("Data Source=VIS-LAPTOP;Initial Catalog=QLBH;Integrated Security=True");
                conn.Open();
                da = new SqlDataAdapter("SELECT * FROM LoaiSanPham", conn);
                ds = new DataSet();
                da.Fill(ds);
                cbbLoaiSanPham.DataSource = ds.Tables[0];
                cbbLoaiSanPham.DisplayMember = "TenLoai";
                cbbLoaiSanPham.ValueMember = "MaLoai";
            }
            catch(SqlException)
            {
                MessageBox.Show("Chưa nhận được dữ liệu");
            }
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadSanPham(cbbLoaiSanPham.SelectedValue.ToString());
        }

        private void Bai6_FormClosing(object sender, FormClosingEventArgs e)
        {
            ds.Dispose();
            ds = null;
            conn.Close();
            conn = null;
        }
    }
}
