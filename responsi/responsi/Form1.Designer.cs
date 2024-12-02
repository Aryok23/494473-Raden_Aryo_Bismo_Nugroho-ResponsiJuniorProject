namespace responsi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pbLogo = new PictureBox();
            lblLogo = new Label();
            lblNama = new Label();
            lblDept = new Label();
            lblInfo = new Label();
            tbNama = new TextBox();
            cbDept = new ComboBox();
            btnInsert = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dgvData = new DataGridView();
            btnLoad = new Button();
            cbJabatan = new ComboBox();
            lblJabatan = new Label();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // pbLogo
            // 
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(12, 12);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(86, 60);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 0;
            pbLogo.TabStop = false;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogo.Location = new Point(29, 76);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(53, 21);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "LOGO";
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.Location = new Point(12, 117);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(99, 15);
            lblNama.TabIndex = 2;
            lblNama.Text = "Nama Karyawan :";
            // 
            // lblDept
            // 
            lblDept.AutoSize = true;
            lblDept.Location = new Point(12, 146);
            lblDept.Name = "lblDept";
            lblDept.Size = new Size(91, 15);
            lblDept.TabIndex = 3;
            lblDept.Text = "Dep. Karyawan :";
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.BackColor = Color.Silver;
            lblInfo.Location = new Point(527, 99);
            lblInfo.Name = "lblInfo";
            lblInfo.Padding = new Padding(3);
            lblInfo.Size = new Size(96, 96);
            lblInfo.TabIndex = 4;
            lblInfo.Text = "ID Departemen:\r\nHR : HR\r\nENG : Engineer\r\nDEV : Developer\r\nPM : Product M\r\nFIN : Finance\r\n";
            // 
            // tbNama
            // 
            tbNama.BorderStyle = BorderStyle.FixedSingle;
            tbNama.Location = new Point(117, 114);
            tbNama.Name = "tbNama";
            tbNama.Size = new Size(157, 23);
            tbNama.TabIndex = 5;
            // 
            // cbDept
            // 
            cbDept.FormattingEnabled = true;
            cbDept.Items.AddRange(new object[] { "HR", "ENG", "DEV", "PM", "FIN" });
            cbDept.Location = new Point(117, 143);
            cbDept.Name = "cbDept";
            cbDept.Size = new Size(157, 23);
            cbDept.TabIndex = 6;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = SystemColors.Control;
            btnInsert.Location = new Point(12, 236);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(100, 30);
            btnInsert.TabIndex = 7;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.Control;
            btnEdit.Location = new Point(194, 236);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 30);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.Control;
            btnDelete.Location = new Point(380, 236);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 30);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvData
            // 
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(12, 283);
            dgvData.Name = "dgvData";
            dgvData.Size = new Size(611, 207);
            dgvData.TabIndex = 10;
            dgvData.CellContentClick += dgvData_CellContentClick;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = SystemColors.Control;
            btnLoad.Location = new Point(380, 528);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(100, 30);
            btnLoad.TabIndex = 11;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // cbJabatan
            // 
            cbJabatan.FormattingEnabled = true;
            cbJabatan.Items.AddRange(new object[] { "Pimpinan", "Manajer", "Staff" });
            cbJabatan.Location = new Point(117, 172);
            cbJabatan.Name = "cbJabatan";
            cbJabatan.Size = new Size(157, 23);
            cbJabatan.TabIndex = 13;
            // 
            // lblJabatan
            // 
            lblJabatan.AutoSize = true;
            lblJabatan.Location = new Point(12, 175);
            lblJabatan.Name = "lblJabatan";
            lblJabatan.Size = new Size(53, 15);
            lblJabatan.TabIndex = 12;
            lblJabatan.Text = "Jabatan :";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 581);
            Controls.Add(cbJabatan);
            Controls.Add(lblJabatan);
            Controls.Add(btnLoad);
            Controls.Add(dgvData);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnInsert);
            Controls.Add(cbDept);
            Controls.Add(tbNama);
            Controls.Add(lblInfo);
            Controls.Add(lblDept);
            Controls.Add(lblNama);
            Controls.Add(lblLogo);
            Controls.Add(pbLogo);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbLogo;
        private Label lblLogo;
        private Label lblNama;
        private Label lblDept;
        private Label lblInfo;
        private TextBox tbNama;
        private ComboBox cbDept;
        private Button btnInsert;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridView dgvData;
        private Button btnLoad;
        private ComboBox cbJabatan;
        private Label lblJabatan;
    }
}
