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
    
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
        }
        SqlConnection conn = null;
        SqlDataAdapter da=null;
        DataSet ds = null;
        private void Bai3_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection("Data Source=VIS-LAPTOP;Initial Catalog=QLBH;Integrated Security=True");
                conn.Open();
                da = new SqlDataAdapter("SELECT * FROM SanPham", conn);
                ds = new DataSet();
                da.Fill(ds);
                cbbSanPham.DataSource = ds.Tables[0];
                cbbSanPham.DisplayMember = "TenSP";
                cbbSanPham.ValueMember = "MaSP";
            }
            catch (SqlException)
            {
                MessageBox.Show("Chưa lấy được dữ liệu!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Bai3_FormClosing(object sender, FormClosingEventArgs e)
        {
            ds.Dispose();
            ds = null;
            conn.Dispose();
            conn = null;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
             MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK) Application.Exit();

        }
    }
}
