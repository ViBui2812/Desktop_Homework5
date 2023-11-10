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
    public partial class Bai2 : Form
    {
        //Chuỗi kết nối
        string strConnectionString = "Data Source = (local); Initial Catalog = QuanLyBanHang; Integrated Security=True; User Id =sa; Password = 123456";
        // Đối tượng kết nối dữ liệu
        SqlConnection conn = null;
        // Đối tượng thực hiện vận chuyển dữ liệu  
        SqlDataAdapter da = null;
        // Đối tượng chứa dữ liệu trong bộ nhớ
        DataSet ds = null;
        public Bai2()
        {
            InitializeComponent();
            

        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                //Khởi động kết nối
                conn = new SqlConnection("Data Source=VIS-LAPTOP;Initial Catalog=QLBH;Integrated Security=True");
                //Mở kết nối
                conn.Open();
                // Vận chuyển dữ liệu
                da = new SqlDataAdapter("SELECT * FROM SanPham", conn);
                //Khởi tạo đối tượng chứa dữ liệu
                ds = new DataSet();
                //Đổ dữ liệu vào DataSet
                da.Fill(ds);
                // Đưa dữ liệu lên ListBox
                lstSanPham.DataSource = ds.Tables[0];
                lstSanPham.DisplayMember = "TenSP";
                lstSanPham.ValueMember = "MaSP";
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!");
            }
            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ds.Dispose();
            ds = null;
            conn.Close();
            conn = null;
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            

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
