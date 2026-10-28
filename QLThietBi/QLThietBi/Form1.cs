
using QLThietBi.Models;
using System.Linq;
namespace QLThietBi
{
    public partial class Form1 : Form
    {
        private string lastValidDonGia = string.Empty;
        private string? selectedMaThietBi;

        public Form1()
        {
            InitializeComponent();
            txtDonGia.TextChanged += txtDonGia_TextChanged;
            btnThoat.Click += btnThoat_Click;
            btnXoa.Click += btnXoa_Click;
            dgvThietBi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThietBi.MultiSelect = false;
            dgvThietBi.SelectionChanged += dgvThietBi_SelectionChanged;
        }

        private void dgvThietBi_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvThietBi.SelectedRows.Count == 0 ||
                dgvThietBi.SelectedRows[0].DataBoundItem is not ThietBi thietBi)
            {
                selectedMaThietBi = null;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                return;
            }

            selectedMaThietBi = thietBi.MaThietBi;
            txtMaThietBi.Text = thietBi.MaThietBi;
            txtTenThietBi.Text = thietBi.TenThietBi;
            txtDonGia.Text = thietBi.DonGia;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void ClearDeviceSelection()
        {
            dgvThietBi.ClearSelection();
            selectedMaThietBi = null;
            txtMaThietBi.Clear();
            txtTenThietBi.Clear();
            txtDonGia.Clear();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (selectedMaThietBi == null)
            {
                return;
            }

            if (MessageBox.Show(this, "Bạn có muốn xóa chương trình này không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using var db = new DuLieu_ThietBiContext();
                var thietBi = db.ThietBi.Find(selectedMaThietBi);
                if (thietBi != null)
                {
                    db.ThietBi.Remove(thietBi);
                    db.SaveChanges();
                }

                dgvThietBi.DataSource = db.ThietBi.ToList();
            }

            ClearDeviceSelection();
        }

        private void btnThoat_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Bạn có muốn thoát không?", "Xác nhận thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void txtDonGia_TextChanged(object? sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtDonGia.Text, @"^-?[0-9]*([.,][0-9]*)?$"))
            {
                lastValidDonGia = txtDonGia.Text;
                return;
            }
            int selectionStart = Math.Clamp(txtDonGia.SelectionStart - 1, 0, lastValidDonGia.Length);
            txtDonGia.Text = lastValidDonGia;
            txtDonGia.SelectionStart = selectionStart;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maThietBi = txtMaThietBi.Text.Trim();
            string tenThietBi = txtTenThietBi.Text.Trim();
            string donGia = txtDonGia.Text.Trim();

            if (string.IsNullOrWhiteSpace(maThietBi) ||
                string.IsNullOrWhiteSpace(tenThietBi) ||
                string.IsNullOrWhiteSpace(donGia))
            {
                MessageBox.Show(this, "Vui lòng nhập đầy đủ thông tin thiết bị.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (maThietBi.Length > 10 || donGia.Length > 12)
            {
                MessageBox.Show(this, "Mã thiết bị tối đa 10 ký tự, đơn giá tối đa 12 ký tự.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(donGia.Replace(',', '.'),
                System.Globalization.NumberStyles.AllowLeadingSign | System.Globalization.NumberStyles.AllowDecimalPoint,
                System.Globalization.CultureInfo.InvariantCulture, out _))
            {
                MessageBox.Show(this, "Vui lòng nhập đơn giá là số nguyên hoặc số thực hợp lệ.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return;
            }
            using var db = new DuLieu_ThietBiContext();
            if (db.ThietBi.Any(thietBi => thietBi.MaThietBi == maThietBi))
            {
                MessageBox.Show(this, "Mã thiết bị đã tồn tại. Vui lòng nhập mã khác.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaThietBi.Focus();
                txtMaThietBi.SelectAll();
                return;
            }
            db.ThietBi.Add(new ThietBi
            {
                MaThietBi = maThietBi,
                TenThietBi = tenThietBi,
                DonGia = donGia
            });
            db.SaveChanges();
            dgvThietBi.DataSource = db.ThietBi.ToList();

            ClearDeviceSelection();
            btnThem.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using var db = new DuLieu_ThietBiContext();
            dgvThietBi.DataSource = db.ThietBi.ToList();
            ClearDeviceSelection();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedMaThietBi == null)
            {
                return;
            }

            string maThietBi = txtMaThietBi.Text.Trim();
            string tenThietBi = txtTenThietBi.Text.Trim();
            string donGia = txtDonGia.Text.Trim();
            if (string.IsNullOrWhiteSpace(maThietBi) ||
                string.IsNullOrWhiteSpace(tenThietBi) ||
                string.IsNullOrWhiteSpace(donGia))
            {
                MessageBox.Show(this, "Vui lòng nhập đầy đủ thông tin thiết bị.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (maThietBi.Length > 10 || donGia.Length > 12)
            {
                MessageBox.Show(this, "Mã thiết bị tối đa 10 ký tự, đơn giá tối đa 12 ký tự.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(donGia.Replace(',', '.'),
                System.Globalization.NumberStyles.AllowLeadingSign | System.Globalization.NumberStyles.AllowDecimalPoint,
                System.Globalization.CultureInfo.InvariantCulture, out _))
            {
                MessageBox.Show(this, "Vui lòng nhập đơn giá là số nguyên hoặc số thực hợp lệ.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return;
            }
            using var db = new DuLieu_ThietBiContext();
            if (maThietBi != selectedMaThietBi)
            {
                MessageBox.Show(this, "Không thể suarw mã thiết bị .", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaThietBi.Focus();
                txtMaThietBi.SelectAll();
                return;
            }
            var tb = db.ThietBi.Find(selectedMaThietBi);
            if (tb == null)
            {
                MessageBox.Show(this, "Thiết bị không còn tồn tại.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvThietBi.DataSource = db.ThietBi.ToList();
                ClearDeviceSelection();
                return;
            }

            tb.TenThietBi = tenThietBi;
            tb.DonGia = donGia;
            try
            {
                db.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                MessageBox.Show("Không lưu được vì dữ liệu thiết bị đã thay đổi.");
                return;
            }
            dgvThietBi.DataSource = db.ThietBi.ToList();
            ClearDeviceSelection();
        }
    }
}
