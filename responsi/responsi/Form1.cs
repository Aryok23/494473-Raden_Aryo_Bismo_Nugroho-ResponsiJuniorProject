using Npgsql;
using System.Data;

namespace responsi
{
    public partial class Form1 : Form
    {
        private NpgsqlConnection conn;
        string connstring = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=responsi";
        public static NpgsqlCommand cmd;
        private string sql = null;
        public DataTable dt;
        private DataGridViewRow row;

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            conn = new NpgsqlConnection(connstring);
            try
            {
                conn.Open();
                dgvData.DataSource = null;
                sql = "select * from st_select()";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvData.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "FAIL!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        public void Add(TextBox tbNama, ComboBox cbDept)
        {
            string namaKaryawan = tbNama.Text;
            string namaDepartemen = cbDept.SelectedItem.ToString();
            int idDepartemen = 0;

            try
            {
                // Membuka koneksi ke database
                using (conn = new NpgsqlConnection(connstring))
                {
                    conn.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT id_dep FROM departemen WHERE nama_departemen = @namaDepartemen", conn))
                    {
                        cmd.Parameters.AddWithValue("@namaDepartemen", namaDepartemen);
                        idDepartemen = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    if (idDepartemen > 0)
                    {
                        using (NpgsqlCommand cmdInsert = new NpgsqlCommand("SELECT insert_karyawan(@nama_karyawan, @id_dep)", conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@nama_karyawan", namaKaryawan);
                            cmdInsert.Parameters.AddWithValue("@id_dep", idDepartemen);

                            int result = Convert.ToInt32(cmdInsert.ExecuteScalar());

                            if (result == 201)
                            {
                                MessageBox.Show("Karyawan berhasil ditambahkan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (result == 404)
                            {
                                MessageBox.Show("Departemen tidak ditemukan", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Departemen tidak valid", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Add(tbNama, cbDept);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                int idKaryawan = Convert.ToInt32(dgvData.SelectedRows[0].Cells["id_emp"].Value);

                string namaKaryawan = tbNama.Text;
                string namaDepartemen = cbDept.SelectedItem.ToString();
                int idDepartemen = 0;

                try
                {
                    using (conn = new NpgsqlConnection(connstring))
                    {
                        conn.Open();

                        using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT id_dep FROM departemen WHERE nama_departemen = @namaDepartemen", conn))
                        {
                            cmd.Parameters.AddWithValue("@namaDepartemen", namaDepartemen);
                            idDepartemen = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        if (idDepartemen > 0)
                        {
                            using (NpgsqlCommand cmdUpdate = new NpgsqlCommand("SELECT edit_karyawan(@id_karyawan, @nama, @id_dept)", conn))
                            {
                                cmdUpdate.Parameters.AddWithValue("@id_karyawan", idKaryawan);
                                cmdUpdate.Parameters.AddWithValue("@nama", namaKaryawan);
                                cmdUpdate.Parameters.AddWithValue("@id_dept", idDepartemen);

                                int result = Convert.ToInt32(cmdUpdate.ExecuteScalar());

                                if (result == 200)
                                {
                                    MessageBox.Show("Karyawan berhasil diperbarui", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else if (result == 404)
                                {
                                    MessageBox.Show("Karyawan tidak ditemukan", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Departemen tidak valid", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LoadData();
            }
            else
            {
                MessageBox.Show("Pilih karyawan yang ingin diperbarui", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                int idKaryawan = Convert.ToInt32(dgvData.SelectedRows[0].Cells["id_emp"].Value);

                try
                {
                    using (conn = new NpgsqlConnection(connstring))
                    {
                        conn.Open();

                        using (NpgsqlCommand cmdDelete = new NpgsqlCommand("SELECT delete_karyawan(@id)", conn))
                        {
                            cmdDelete.Parameters.AddWithValue("@id", idKaryawan);
                            int result = Convert.ToInt32(cmdDelete.ExecuteScalar());

                            if (result == 204)
                            {
                                MessageBox.Show("Karyawan berhasil dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (result == 404)
                            {
                                MessageBox.Show("Karyawan tidak ditemukan", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LoadData();
            }
            else
            {
                MessageBox.Show("Pilih karyawan yang ingin dihapus", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                row = dgvData.Rows[e.RowIndex];
                tbNama.Text = row.Cells["nama_emp"].Value.ToString();
                cbDept.SelectedItem = row.Cells["nama_dept"].Value.ToString();
            }
        }
    }
}


/*using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace dgvDept
{
    public partial class Form1 : Form
    {

        private NpgsqlConnection conn;
        string connstring = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=responsi";
        public static NpgsqlCommand cmd;
        private string sql = null;
        public DataTable dt;
        private DataGridViewRow row;

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // conn = new NpgsqlConnection(connstring);       
        }

        private void LoadData()
        {
            conn = new NpgsqlConnection(connstring);
            try
            {
                conn.Open();
                dgvKaryawan.DataSource = null;
                sql = "select * from st_select()";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvKaryawan.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "FAIL!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        public void Add(TextBox tbNama, ComboBox cbDepartemen)
        {
            string namaKaryawan = tbNama.Text;
            string namaDepartemen = cbDepartemen.SelectedItem.ToString();
            int idDepartemen = 0;

            try
            {
                // Membuka koneksi ke database
                using (conn = new NpgsqlConnection(connstring))
                {
                    conn.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT id FROM departemen WHERE nama = @namaDepartemen", conn))
                    {
                        cmd.Parameters.AddWithValue("@namaDepartemen", namaDepartemen);
                        idDepartemen = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    if (idDepartemen > 0)
                    {
                        using (NpgsqlCommand cmdInsert = new NpgsqlCommand("SELECT insert_karyawan(@nama, @id_dept)", conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@nama", namaKaryawan);
                            cmdInsert.Parameters.AddWithValue("@id_dept", idDepartemen);

                            int result = Convert.ToInt32(cmdInsert.ExecuteScalar());

                            if (result == 201)
                            {
                                MessageBox.Show("Karyawan berhasil ditambahkan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (result == 404)
                            {
                                MessageBox.Show("Departemen tidak ditemukan", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Departemen tidak valid", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Add(tbNama, cbDepartemen);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvKaryawan.SelectedRows.Count > 0)
            {
                // Ambil id karyawan yang dipilih
                int idKaryawan = Convert.ToInt32(dgvKaryawan.SelectedRows[0].Cells["id_karyawan"].Value);

                // Ambil nama karyawan dan departemen yang dipilih
                string namaKaryawan = tbNama.Text;
                string namaDepartemen = cbDepartemen.SelectedItem.ToString();
                int idDepartemen = 0;

                try
                {
                    using (conn = new NpgsqlConnection(connstring))
                    {
                        conn.Open();

                        // Ambil id departemen berdasarkan nama departemen yang dipilih
                        using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT id FROM departemen WHERE nama = @namaDepartemen", conn))
                        {
                            cmd.Parameters.AddWithValue("@namaDepartemen", namaDepartemen);
                            idDepartemen = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        if (idDepartemen > 0)
                        {
                            // Panggil fungsi untuk update karyawan
                            using (NpgsqlCommand cmdUpdate = new NpgsqlCommand("SELECT edit_karyawan(@id, @nama, @id_dept)", conn))
                            {
                                cmdUpdate.Parameters.AddWithValue("@id", idKaryawan);
                                cmdUpdate.Parameters.AddWithValue("@nama", namaKaryawan);
                                cmdUpdate.Parameters.AddWithValue("@id_dept", idDepartemen);

                                int result = Convert.ToInt32(cmdUpdate.ExecuteScalar());

                                if (result == 200)
                                {
                                    MessageBox.Show("Karyawan berhasil diperbarui", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else if (result == 404)
                                {
                                    MessageBox.Show("Karyawan tidak ditemukan", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Departemen tidak valid", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LoadData();  // Reload data setelah update
            }
            else
            {
                MessageBox.Show("Pilih karyawan yang ingin diperbarui", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvKaryawan.SelectedRows.Count > 0)
            {
                // Ambil id karyawan yang dipilih
                int idKaryawan = Convert.ToInt32(dgvKaryawan.SelectedRows[0].Cells["id_karyawan"].Value);

                try
                {
                    using (conn = new NpgsqlConnection(connstring))
                    {
                        conn.Open();

                        // Panggil fungsi untuk delete karyawan
                        using (NpgsqlCommand cmdDelete = new NpgsqlCommand("SELECT delete_karyawan(@id)", conn))
                        {
                            cmdDelete.Parameters.AddWithValue("@id", idKaryawan);
                            int result = Convert.ToInt32(cmdDelete.ExecuteScalar());

                            if (result == 204)
                            {
                                MessageBox.Show("Karyawan berhasil dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (result == 404)
                            {
                                MessageBox.Show("Karyawan tidak ditemukan", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LoadData();  // Reload data setelah delete
            }
            else
            {
                MessageBox.Show("Pilih karyawan yang ingin dihapus", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvKaryawan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                row = dgvKaryawan.Rows[e.RowIndex];
                tbNama.Text = row.Cells["nama_karyawan"].Value.ToString();
                cbDepartemen.SelectedItem = row.Cells["nama_departemen"].Value.ToString();
            }
        }
    }
}*/