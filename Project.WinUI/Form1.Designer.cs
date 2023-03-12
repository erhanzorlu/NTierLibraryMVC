
namespace Project.WinUI
{
    partial class Form1
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
            this.lstAuthors = new System.Windows.Forms.ListBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnAktif = new System.Windows.Forms.Button();
            this.btnPasif = new System.Windows.Forms.Button();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBK = new System.Windows.Forms.Button();
            this.kucuntenB = new System.Windows.Forms.Button();
            this.txtSırala = new System.Windows.Forms.TextBox();
            this.btnGuncel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstAuthors
            // 
            this.lstAuthors.FormattingEnabled = true;
            this.lstAuthors.ItemHeight = 16;
            this.lstAuthors.Location = new System.Drawing.Point(290, 18);
            this.lstAuthors.Name = "lstAuthors";
            this.lstAuthors.Size = new System.Drawing.Size(236, 260);
            this.lstAuthors.TabIndex = 0;
            this.lstAuthors.SelectedIndexChanged += new System.EventHandler(this.lstAuthors_SelectedIndexChanged);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(12, 118);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(112, 37);
            this.btnEkle.TabIndex = 1;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(12, 70);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(100, 22);
            this.txtAd.TabIndex = 2;
            // 
            // txtSoyad
            // 
            this.txtSoyad.Location = new System.Drawing.Point(166, 70);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(100, 22);
            this.txtSoyad.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(161, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Soyadı";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(154, 118);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(112, 37);
            this.btnGuncelle.TabIndex = 8;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(86, 186);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(112, 37);
            this.btnSil.TabIndex = 9;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnAktif
            // 
            this.btnAktif.Location = new System.Drawing.Point(532, 23);
            this.btnAktif.Name = "btnAktif";
            this.btnAktif.Size = new System.Drawing.Size(112, 37);
            this.btnAktif.TabIndex = 10;
            this.btnAktif.Text = "Aktif";
            this.btnAktif.UseVisualStyleBackColor = true;
            this.btnAktif.Click += new System.EventHandler(this.btnAktif_Click);
            // 
            // btnPasif
            // 
            this.btnPasif.Location = new System.Drawing.Point(669, 23);
            this.btnPasif.Name = "btnPasif";
            this.btnPasif.Size = new System.Drawing.Size(112, 37);
            this.btnPasif.TabIndex = 11;
            this.btnPasif.Text = "Pasif";
            this.btnPasif.UseVisualStyleBackColor = true;
            this.btnPasif.Click += new System.EventHandler(this.btnPasif_Click);
            // 
            // txtAra
            // 
            this.txtAra.Location = new System.Drawing.Point(110, 248);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(100, 22);
            this.txtAra.TabIndex = 12;
            this.txtAra.TextChanged += new System.EventHandler(this.txtAra_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(58, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ara";
            // 
            // btnBK
            // 
            this.btnBK.Location = new System.Drawing.Point(532, 233);
            this.btnBK.Name = "btnBK";
            this.btnBK.Size = new System.Drawing.Size(84, 37);
            this.btnBK.TabIndex = 14;
            this.btnBK.Text = "BüyüktenK";
            this.btnBK.UseVisualStyleBackColor = true;
            this.btnBK.Click += new System.EventHandler(this.btnBK_Click);
            // 
            // kucuntenB
            // 
            this.kucuntenB.Location = new System.Drawing.Point(697, 233);
            this.kucuntenB.Name = "kucuntenB";
            this.kucuntenB.Size = new System.Drawing.Size(84, 37);
            this.kucuntenB.TabIndex = 15;
            this.kucuntenB.Text = "KücüktenB";
            this.kucuntenB.UseVisualStyleBackColor = true;
            this.kucuntenB.Click += new System.EventHandler(this.kucuntenB_Click);
            // 
            // txtSırala
            // 
            this.txtSırala.Location = new System.Drawing.Point(587, 193);
            this.txtSırala.Name = "txtSırala";
            this.txtSırala.Size = new System.Drawing.Size(136, 22);
            this.txtSırala.TabIndex = 16;
            // 
            // btnGuncel
            // 
            this.btnGuncel.Location = new System.Drawing.Point(600, 89);
            this.btnGuncel.Name = "btnGuncel";
            this.btnGuncel.Size = new System.Drawing.Size(112, 37);
            this.btnGuncel.TabIndex = 17;
            this.btnGuncel.Text = "Güncel";
            this.btnGuncel.UseVisualStyleBackColor = true;
            this.btnGuncel.Click += new System.EventHandler(this.btnGuncel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(594, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 25);
            this.label5.TabIndex = 19;
            this.label5.Text = "Sayı giriniz";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 288);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGuncel);
            this.Controls.Add(this.txtSırala);
            this.Controls.Add(this.kucuntenB);
            this.Controls.Add(this.btnBK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAra);
            this.Controls.Add(this.btnPasif);
            this.Controls.Add(this.btnAktif);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSoyad);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.lstAuthors);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstAuthors;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnAktif;
        private System.Windows.Forms.Button btnPasif;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBK;
        private System.Windows.Forms.Button kucuntenB;
        private System.Windows.Forms.TextBox txtSırala;
        private System.Windows.Forms.Button btnGuncel;
        private System.Windows.Forms.Label label5;
    }
}

