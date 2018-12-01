using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace SpotifyHesapKontrol
{
    public partial class AnaForm : Form
    {
        private const string Baslik = "Spotify Hesap Kontrolü by Memba Co.";
        private const string Version = " V 1.0.0";
        private Thread CheckerThread;

        public AnaForm()
        {
            InitializeComponent();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            this.Text = $" {Baslik} {Version}";
            this.HesapGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        #region Listeden Hesap Ekleme

        private void BtnListeSec_Click(object sender, EventArgs e)
        {
            HesapEkleDialog.ShowDialog();
        }

        private void HesapEkleDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (HesapYonetim.HesapYukle(HesapEkleDialog.FileName))
            {
                    MessageBox.Show(
                    "Hesaplar Yüklendi.",
                    "Bilgi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }
            else
            {
                ShowErrorMessage("Hesap Bulunamadı. Listenizi Kontrol Edin!");
            }
        }

        #endregion Listeden Hesap Ekleme

        #region Hata Mesajı Fonsiyonu

        private void ShowErrorMessage(string Content, string Title = "Hata")
        {
            MessageBox.Show(
                Content,
                Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
        }

        #endregion Hata Mesajı Fonsiyonu

        #region Bulunan Hesap Sayısı Getir

        private void CalismaTimer_Tick(object sender, EventArgs e)
        {
            lblCalisan.Text = HesapGrid.Rows.Count.ToString();
        }

        #endregion Bulunan Hesap Sayısı Getir

        #region Kontrolü Başlat

        private void BtnBaslat_Click(object sender, EventArgs e)
        {
            BtnBaslat.Enabled = false;

            CheckerThread = new Thread(() =>
            {
                new Kontrolcu(Decimal.ToInt32(MaxIs.Value), this).Start();
            });
            CheckerThread.Start();

            IsParcasiTimer.Start();
            CalismaTimer.Start();

            BeklePanel.Visible = true;
        }

        #endregion Kontrolü Başlat

        #region Grid Güncelleme

        public void HesapGridGuncelle(Hesap _Hesap)
        {
            if (HesapGrid.InvokeRequired)
            {
                HesapGrid.Invoke((MethodInvoker)(() => this.HesapGrid.Rows.Add(_Hesap.KulAdi, _Hesap.Sifre)));
            }
            else
            {
                this.HesapGrid.Rows.Add(_Hesap.KulAdi, _Hesap.Sifre);
            }
        }

        #endregion Grid Güncelleme

        #region Çıkartılacak Veri Dialoğu

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (HesapGrid.Rows.Count > 0)
            {
                HesapCikartDialog.ShowDialog();
            }
            else
            {
                ShowErrorMessage("Çıkartılacak Veri Bulunamadı!");
            }
        }

        #endregion Çıkartılacak Veri Dialoğu

        #region İş Bitti Timer

        private void IsParcasiTimer_Tick(object sender, EventArgs e)
        {
            if (!CheckerThread.IsAlive)
            {
                IsParcasiTimer.Stop();
                CalismaTimer.Stop();

                MessageBox.Show(
                    "Kontrol Tamamlandı!",
                    "Bilgi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                BtnBaslat.Enabled = true;

                BeklePanel.Visible = false;
            }
        }

        #endregion İş Bitti Timer

        #region İşlem Sırasında Çıkış Yap

            private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CheckerThread != null && CheckerThread.IsAlive)
            {
                ShowErrorMessage("Hesaplar Kontrol edilirken Çıkış yapamazsınız...");
                e.Cancel = true;
            }
        }

        #endregion İşlem Sırasında Çıkış Yap

        #region Hesapları Çıkart

        private void BtnHesapCikart_Click(object sender, EventArgs e)
        {
            if (HesapGrid.Rows.Count > 0)
            {
                HesapCikartDialog.ShowDialog();
            }
            else
            {
                ShowErrorMessage("Çıkartma Başarısız Oldu!");
            }
        }

        private void HesapCikartDialog_FileOk(object sender, CancelEventArgs e)
        {
            string Path = HesapCikartDialog.FileName;

            using (StreamWriter WriteAccountsStream = new StreamWriter(Path, true))
            {
                if (File.Exists(Path)) WriteAccountsStream.Write("");

                foreach (DataGridViewRow SingleAccount in HesapGrid.Rows)
                {
                    WriteAccountsStream.WriteLine($"{SingleAccount.Cells["KulAdi"].Value.ToString()}:{SingleAccount.Cells["Sifre"].Value.ToString()}");
                }
            }

            MessageBox.Show(
                "Çıkartma İşlemi Tamamlandı.",
                "Bilgi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }

        #endregion Hesapları Çıkart
    }
}