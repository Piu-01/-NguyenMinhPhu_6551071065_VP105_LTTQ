namespace QLThietBi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtMaThietBi = new TextBox();
            txtTenThietBi = new TextBox();
            txtDonGia = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnThem = new Button();
            btnThoat = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            label6 = new Label();
            dgvThietBi = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvThietBi).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(543, 9);
            label1.Name = "label1";
            label1.Size = new Size(123, 20);
            label1.TabIndex = 0;
            label1.Text = "Thông tin thiêt bị";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(553, 79);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên thiết bị:";
            // 
            // txtMaThietBi
            // 
            txtMaThietBi.Location = new Point(663, 45);
            txtMaThietBi.Name = "txtMaThietBi";
            txtMaThietBi.Size = new Size(125, 27);
            txtMaThietBi.TabIndex = 2;
            // 
            // txtTenThietBi
            // 
            txtTenThietBi.Location = new Point(663, 79);
            txtTenThietBi.Name = "txtTenThietBi";
            txtTenThietBi.Size = new Size(125, 27);
            txtTenThietBi.TabIndex = 3;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(663, 112);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(125, 27);
            txtDonGia.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(553, 45);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 5;
            label3.Text = "Mã thiết bị:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(553, 112);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 6;
            label4.Text = "Đơn giá:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(543, 190);
            label5.Name = "label5";
            label5.Size = new Size(66, 20);
            label5.TabIndex = 7;
            label5.Text = "Thao tác";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(572, 232);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 8;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(684, 232);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 9;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Enabled = false;
            btnSua.Location = new Point(572, 289);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 10;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Enabled = false;
            btnXoa.Location = new Point(684, 289);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 9);
            label6.Name = "label6";
            label6.Size = new Size(128, 20);
            label6.TabIndex = 12;
            label6.Text = "Danh sách thiết bị";
            // 
            // dgvThietBi
            // 
            dgvThietBi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThietBi.Location = new Point(12, 32);
            dgvThietBi.Name = "dgvThietBi";
            dgvThietBi.RowHeadersWidth = 51;
            dgvThietBi.Size = new Size(512, 395);
            dgvThietBi.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvThietBi);
            Controls.Add(label6);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThoat);
            Controls.Add(btnThem);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtDonGia);
            Controls.Add(txtTenThietBi);
            Controls.Add(txtMaThietBi);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvThietBi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtMaThietBi;
        private TextBox txtTenThietBi;
        private TextBox txtDonGia;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnThem;
        private Button btnThoat;
        private Button btnSua;
        private Button btnXoa;
        private Label label6;
        private DataGridView dgvThietBi;
    }
}
