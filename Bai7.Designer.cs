namespace Desktop_Homework5
{
    partial class Bai7
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trvLoaiSanPham = new System.Windows.Forms.TreeView();
            this.dgSanPham = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại Sản Phẩm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sản Phẩm";
            // 
            // trvLoaiSanPham
            // 
            this.trvLoaiSanPham.Location = new System.Drawing.Point(91, 125);
            this.trvLoaiSanPham.Name = "trvLoaiSanPham";
            this.trvLoaiSanPham.Size = new System.Drawing.Size(142, 166);
            this.trvLoaiSanPham.TabIndex = 2;
            this.trvLoaiSanPham.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvLoaiSanPham_AfterSelect);
            // 
            // dgSanPham
            // 
            this.dgSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSanPham.Location = new System.Drawing.Point(260, 125);
            this.dgSanPham.Name = "dgSanPham";
            this.dgSanPham.RowHeadersWidth = 51;
            this.dgSanPham.RowTemplate.Height = 24;
            this.dgSanPham.Size = new System.Drawing.Size(430, 166);
            this.dgSanPham.TabIndex = 3;
            // 
            // Bai7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgSanPham);
            this.Controls.Add(this.trvLoaiSanPham);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Bai7";
            this.Text = "Bai7";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bai7_FormClosing);
            this.Load += new System.EventHandler(this.Bai7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView trvLoaiSanPham;
        private System.Windows.Forms.DataGridView dgSanPham;
    }
}