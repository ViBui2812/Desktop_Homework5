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
    public partial class Bai7 : Form
    {
        public Bai7()
        {
            InitializeComponent();
        }
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        void LoadSanPham( string maloai)
        {
            try
            {
                da = null;
                ds = new DataSet();
                da = new SqlDataAdapter("Select * from SanPham where MaLoai = '" + maloai + "'", conn);
                da.Fill(ds, "SanPham");
                dgSanPham.DataSource = ds.Tables["SanPham"];
            }
            catch (SqlException)
            {
                MessageBox.Show("Chưa nhận được dữ liệu");
            }
        }
        private void Bai7_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection("Data Source=VIS-LAPTOP;Initial Catalog=QLBH;Integrated Security=True");
                conn.Open();
                da = new SqlDataAdapter("Select * from LoaiSanPham", conn);
                ds = new DataSet();
                da.Fill(ds, "LoaiSanPham");
                TreeNode node;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    node = new TreeNode();
                    node.Text = dr["TenLoai"].ToString(); //hiển thị ra bên ngoài
                    node.Tag = dr["MaLoai"].ToString(); //giá trị khi được chọn
                    trvLoaiSanPham.Nodes.Add(node);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Chưa nhận được dữ liệu");
            }

        }

        private void trvLoaiSanPham_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadSanPham(trvLoaiSanPham.SelectedNode.Tag.ToString());
        }

        private void Bai7_FormClosing(object sender, FormClosingEventArgs e)
        {
            ds.Dispose();
            ds = null;
            conn.Close();
            conn = null;
        }
    }
}
