namespace SpotifyHesapKontrol
{
    partial class AnaForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            this.HesapGrid = new System.Windows.Forms.DataGridView();
            this.KulAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sifre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnBaslat = new System.Windows.Forms.Button();
            this.BtnHesapCikart = new System.Windows.Forms.Button();
            this.BtnListeSec = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BeklePanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.IslemBar = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MaxIs = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCalisan = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HesapEkleDialog = new System.Windows.Forms.OpenFileDialog();
            this.CalismaTimer = new System.Windows.Forms.Timer(this.components);
            this.IsParcasiTimer = new System.Windows.Forms.Timer(this.components);
            this.HesapCikartDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.HesapGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.BeklePanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxIs)).BeginInit();
            this.SuspendLayout();
            // 
            // HesapGrid
            // 
            this.HesapGrid.AllowUserToAddRows = false;
            this.HesapGrid.AllowUserToDeleteRows = false;
            this.HesapGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HesapGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KulAdi,
            this.Sifre});
            resources.ApplyResources(this.HesapGrid, "HesapGrid");
            this.HesapGrid.Name = "HesapGrid";
            this.HesapGrid.ReadOnly = true;
            // 
            // KulAdi
            // 
            resources.ApplyResources(this.KulAdi, "KulAdi");
            this.KulAdi.Name = "KulAdi";
            this.KulAdi.ReadOnly = true;
            // 
            // Sifre
            // 
            resources.ApplyResources(this.Sifre, "Sifre");
            this.Sifre.Name = "Sifre";
            this.Sifre.ReadOnly = true;
            // 
            // BtnBaslat
            // 
            resources.ApplyResources(this.BtnBaslat, "BtnBaslat");
            this.BtnBaslat.Name = "BtnBaslat";
            this.BtnBaslat.UseVisualStyleBackColor = true;
            this.BtnBaslat.Click += new System.EventHandler(this.BtnBaslat_Click);
            // 
            // BtnHesapCikart
            // 
            resources.ApplyResources(this.BtnHesapCikart, "BtnHesapCikart");
            this.BtnHesapCikart.Name = "BtnHesapCikart";
            this.BtnHesapCikart.UseVisualStyleBackColor = true;
            this.BtnHesapCikart.Click += new System.EventHandler(this.BtnHesapCikart_Click);
            // 
            // BtnListeSec
            // 
            resources.ApplyResources(this.BtnListeSec, "BtnListeSec");
            this.BtnListeSec.Name = "BtnListeSec";
            this.BtnListeSec.UseVisualStyleBackColor = true;
            this.BtnListeSec.Click += new System.EventHandler(this.BtnListeSec_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BeklePanel);
            this.panel1.Controls.Add(this.HesapGrid);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // BeklePanel
            // 
            this.BeklePanel.Controls.Add(this.label2);
            this.BeklePanel.Controls.Add(this.IslemBar);
            resources.ApplyResources(this.BeklePanel, "BeklePanel");
            this.BeklePanel.Name = "BeklePanel";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // IslemBar
            // 
            resources.ApplyResources(this.IslemBar, "IslemBar");
            this.IslemBar.Name = "IslemBar";
            this.IslemBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnListeSec);
            this.panel2.Controls.Add(this.BtnBaslat);
            this.panel2.Controls.Add(this.BtnHesapCikart);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.MaxIs);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lblCalisan);
            this.panel3.Controls.Add(this.label1);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SpotifyHesapKontrol.Properties.Resources.MembaCoDevLogo;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // MaxIs
            // 
            resources.ApplyResources(this.MaxIs, "MaxIs");
            this.MaxIs.Name = "MaxIs";
            this.MaxIs.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // lblCalisan
            // 
            resources.ApplyResources(this.lblCalisan, "lblCalisan");
            this.lblCalisan.Name = "lblCalisan";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // HesapEkleDialog
            // 
            resources.ApplyResources(this.HesapEkleDialog, "HesapEkleDialog");
            this.HesapEkleDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.HesapEkleDialog_FileOk);
            // 
            // CalismaTimer
            // 
            this.CalismaTimer.Tick += new System.EventHandler(this.CalismaTimer_Tick);
            // 
            // IsParcasiTimer
            // 
            this.IsParcasiTimer.Tick += new System.EventHandler(this.IsParcasiTimer_Tick);
            // 
            // HesapCikartDialog
            // 
            resources.ApplyResources(this.HesapCikartDialog, "HesapCikartDialog");
            this.HesapCikartDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.HesapCikartDialog_FileOk);
            // 
            // AnaForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnaForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnaForm_FormClosing);
            this.Load += new System.EventHandler(this.AnaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HesapGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.BeklePanel.ResumeLayout(false);
            this.BeklePanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxIs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView HesapGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn KulAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sifre;
        private System.Windows.Forms.Button BtnBaslat;
        private System.Windows.Forms.Button BtnHesapCikart;
        private System.Windows.Forms.Button BtnListeSec;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown MaxIs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCalisan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog HesapEkleDialog;
        private System.Windows.Forms.Timer CalismaTimer;
        private System.Windows.Forms.Timer IsParcasiTimer;
        private System.Windows.Forms.SaveFileDialog HesapCikartDialog;
        private System.Windows.Forms.ProgressBar IslemBar;
        private System.Windows.Forms.Panel BeklePanel;
        private System.Windows.Forms.Label label2;
    }
}

